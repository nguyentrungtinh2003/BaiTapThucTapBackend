using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IXNKNhapKhoService
    {
        Task<bool> HandleAdjustmentAsync(XNKNhapKho model);
    }
}
