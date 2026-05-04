using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IKhoUserService
    {
        Task<List<KhoUserDto>> GetAll();
        Task<KhoUserDto> Create(CreateKhoUserRequest request);
        Task Delete(string MaDangNhap, int KhoID);
    }
}
