using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class KhoUserService : IKhoUserService
    {
        private readonly IKhoUserRepository _repo;
        private readonly NormalizeService _normalizeService;

        public KhoUserService(IKhoUserRepository repo,NormalizeService normalizeService)
        {
            _repo = repo;
            _normalizeService = normalizeService;
        }

        public async Task<List<KhoUserDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(x => x.ToDto()).ToList();
        }

        public async Task<List<KhoUser>> GetByUser(string Ma_Dang_Nhap)
        {
            return await _repo.GetByUser(Ma_Dang_Nhap);
        }
        public async Task Create(CreateKhoUserRequest request)
        {
            request.Ma_Dang_Nhap = _normalizeService.Normalize(request.Ma_Dang_Nhap);

            if (string.IsNullOrEmpty(request.Ma_Dang_Nhap))
            {
                throw new Exception("Mã đãng nhập không hợp lệ");
            }
            if(request.Kho_ID <= 0)
            {
                throw new Exception("Kho ID không hợp lệ");
            }

            var exists = await _repo.Exists(request.Ma_Dang_Nhap,request.Kho_ID);

            if(exists)
            {
                throw new Exception("Phân quyền đã tồn tại");
            }

            var entity = KhoUserMapping.ToEntity(request);
            await _repo.Add(entity);
            
        }

        public async Task Delete(string Ma_Dang_Nhap, int Kho_ID)
        {
            var entity = await _repo.Get(Ma_Dang_Nhap, Kho_ID);
            if(entity == null)
            {
                throw new Exception("Không tìm thấy");
            }

            await _repo.Delete(entity);
        }

    }
}
