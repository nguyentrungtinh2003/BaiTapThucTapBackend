using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class LoaiSanPhamService : ILoaiSanPhamService
    {
        private readonly ILoaiSanPhamRepository _repo;
        private readonly NormalizeService _normalizeService;

        public LoaiSanPhamService(ILoaiSanPhamRepository repo, NormalizeService normalizeService)
        {
            _repo = repo;
            _normalizeService = normalizeService;
        }

        public async Task<List<LoaiSanPhamDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(x => x.ToDto()).ToList();
        }

        public async Task<LoaiSanPhamDto> Create(CreateLoaiSanPhamRequest request)
        {
            request.Ma_LSP = _normalizeService.Normalize(request.Ma_LSP);
            request.Ten_LSP = _normalizeService.Normalize(request.Ten_LSP);
            request.Ghi_Chu = request.Ghi_Chu?.Trim();

            if (string.IsNullOrEmpty(request.Ma_LSP))
            {
                throw new Exception("Ma_LSP không được rỗng");
            }
            if(string.IsNullOrEmpty(request.Ten_LSP))
            {
                throw new Exception("Ten_LSP không được rỗng");
            }

            var existsMa = await _repo.ExistsMa(request.Ma_LSP);

            if (existsMa)
            {
                throw new Exception("Mã loại sản phẩm đã tồn tại");
            }

            var existsTen = await _repo.ExistsTen(request.Ten_LSP);

            if (existsTen)
            {
                throw new Exception("Tên loại sản phẩm đã tồn tại");
            }

            var entity = new LoaiSanPham
            {
                Ma_LSP = request.Ma_LSP,
                Ten_LSP = request.Ten_LSP,
                Ghi_Chu = request.Ghi_Chu,
            };

            await _repo.Add(entity);
            return entity.ToDto();

        }

        public async Task<LoaiSanPhamDto> Update(int id, CreateLoaiSanPhamRequest request)
        {
            request.Ma_LSP = _normalizeService.Normalize(request.Ma_LSP);
            request.Ten_LSP = _normalizeService.Normalize(request.Ten_LSP);
            request.Ghi_Chu = request.Ghi_Chu?.Trim();

            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Không tìm thấy");
            }

            var existsMa = await _repo.ExistsMa(request.Ma_LSP);

            if (existsMa)
            {
                throw new Exception("Mã loại sản phẩm đã tồn tại");
            }

            var existsTen = await _repo.ExistsTen(request.Ten_LSP);

            if (existsTen)
            {
                throw new Exception("Tên loại sản phẩm đã tồn tại");
            }

            entity.Ma_LSP = request.Ma_LSP;
            entity.Ten_LSP = request.Ten_LSP;
            entity.Ghi_Chu = request.Ghi_Chu;

            await _repo.Update(entity);
            return entity.ToDto();
        }

        public async Task Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Không tìm thấy");
            }

            await _repo.Delete(entity);
        }
    }
}
