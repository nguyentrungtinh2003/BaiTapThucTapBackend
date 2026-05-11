using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class KhoService : IKhoService
    {
        private readonly IKhoRepository _repo;
        private readonly NormalizeService _normalizeService;

        public KhoService(IKhoRepository repo, NormalizeService normalizeService)
        {
            _repo = repo;
            _normalizeService = normalizeService;
        }

        public async Task<List<KhoDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(x => x.ToDto()).ToList();
        }
        public async Task<KhoDto> GetById(int id)
        {
            var result =  await _repo.GetById(id);
            if(result == null)
            {
                throw new Exception("Khong tim thay");
            }
            return result.ToDto();
        }
        public async Task<KhoDto> Create(CreateKhoRequest request)
        {
            request.Ten_Kho = _normalizeService.Normalize(request.Ten_Kho);
            request.Ghi_Chu = request.Ghi_Chu?.Trim();

            if (string.IsNullOrEmpty(request.Ten_Kho))
            {
                throw new Exception("Tên kho không được rỗng");
            }

            if (await _repo.ExistsTen(request.Ten_Kho))
            {
                throw new Exception("Tên kho đã tồn tại");
            }

            var entity = new Kho
            {
                Ten_Kho = request.Ten_Kho,
                Ghi_Chu = request.Ghi_Chu,
            };

            await _repo.Add(entity);
            return entity.ToDto();
        }

        public async Task<KhoDto> Update(int id, CreateKhoRequest request)
        {
            request.Ten_Kho = _normalizeService.Normalize(request.Ten_Kho);
            request.Ghi_Chu = request.Ghi_Chu?.Trim();

            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Không tịm thấy kho");
            }

            if (string.IsNullOrEmpty(request.Ten_Kho))
            {
                throw new Exception("Tên kho không được rỗng");
            }

            if (await _repo.ExistsTen(request.Ten_Kho))
            {
                throw new Exception("Tên kho đã tồn tại");
            }

            entity.Ten_Kho = request.Ten_Kho;
            entity.Ghi_Chu = request.Ghi_Chu;

            await _repo.Update(entity);
            return entity.ToDto();
        }

        public async Task Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Không tịm thấy kho");
            }

            await _repo.Delete(entity);
        }
    }
}
