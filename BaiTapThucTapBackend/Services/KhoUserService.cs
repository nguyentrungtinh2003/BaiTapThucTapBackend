using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class KhoUserService : IKhoUserService
    {
        private readonly IKhoUserRepository _repo;

        public KhoUserService(IKhoUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<KhoUserDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(x => x.ToDto()).ToList();
        }

        public async Task<KhoUserDto> Create(CreateKhoUserRequest request)
        {
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
            return KhoUserMapping.ToDto(entity);
        }

        public async Task Delete(string MaDangNhap, int KhoID)
        {
            var entity = await _repo.Get(MaDangNhap, KhoID);
            if(entity == null)
            {
                throw new Exception("Không tìm thấy");
            }

            await _repo.Delete(entity);
        }

    }
}
