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
            if (request.User_ID <= 0)
            {
                throw new Exception("User ID khong hop le");
            }
            if(request.Kho_ID <= 0)
            {
                throw new Exception("Kho ID khong hop le");
            }

            var exists = await _repo.Exists(request.User_ID,request.Kho_ID);

            if(exists)
            {
                throw new Exception("Phan quyen da ton tai");
            }

            var entity = KhoUserMapping.ToEntity(request);
            await _repo.Add(entity);
            return KhoUserMapping.ToDto(entity);
        }

        public async Task Delete(int UserID, int KhoID)
        {
            var entity = await _repo.Get(UserID, KhoID);
            if(entity == null)
            {
                throw new Exception("Khong tim thay");
            }

            await _repo.Delete(entity);
        }

    }
}
