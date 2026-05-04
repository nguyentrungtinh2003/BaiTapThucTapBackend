using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IXNKNhapKhoDetailService
    {
        Task<bool> UpdateDetailAdjustmentAsync(int headerId, List<XNKNhapKhoDetail> newDetails);
    }
}
