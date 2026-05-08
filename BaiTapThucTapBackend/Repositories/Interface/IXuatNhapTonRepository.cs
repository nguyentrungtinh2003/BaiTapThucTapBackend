using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IXuatNhapTonRepository
    {
        Task<List<BaoCaoXuatNhapTonDto>> BaoCaoXuatNhapTon(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin);
    }
}
