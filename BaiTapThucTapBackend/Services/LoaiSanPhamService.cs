using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class LoaiSanPhamService : ILoaiSanPhamService
    {
        private readonly ILoaiSanPhamRepository _repo;

        public LoaiSanPhamService(ILoaiSanPhamRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<LoaiSanPhamDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(x => x.ToDto()).ToList();
        }

        public async Task<LoaiSanPhamDto> Create(CreateLoaiSanPhamRequest request)
        {
            if(string.IsNullOrEmpty(request.Ma_LSP))
            {
                throw new Exception("Ma_LSP không được rỗng");
            }
            if(string.IsNullOrEmpty(request.Ten_LSP))
            {
                throw new Exception("Ten_LSP không được rỗng");
            }

            var entity = new LoaiSanPham
            {
                Ma_LSP = request.Ma_LSP,
                Ten_LSP = request.Ten_LSP,
                Ghi_Chu = request.Ghi_Chu
            };

            await _repo.Add(entity);
            return entity.ToDto();

        }

        public async Task<LoaiSanPhamDto> Update(int id, CreateLoaiSanPhamRequest request)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Không tìm thấy");
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
