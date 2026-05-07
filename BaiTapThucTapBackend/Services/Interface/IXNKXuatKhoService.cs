using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IXNKXuatKhoService
    {
        Task<bool> HandleAdjustmentAsync(CreateXNKXuatKhoRequest model);
    }
}
