using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IXuatNhapTonService
    {
        Task<List<BaoCaoXuatNhapTonDto>> BaoCaoXuatNhapTon(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin);
    }
}
