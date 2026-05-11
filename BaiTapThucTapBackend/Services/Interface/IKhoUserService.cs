using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IKhoUserService
    {
        Task<List<KhoUserDto>> GetAll();
        Task<List<KhoUser>> GetByUser(string Ma_Dang_Nhap);
        Task Create(CreateKhoUserRequest request);
        Task Delete(string Ma_Dang_Nhap, int Kho_ID);
    }
}
