using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class XuatNhapTonService : IXuatNhapTonService
    {
        private readonly IXuatNhapTonRepository _repo;
        public XuatNhapTonService(IXuatNhapTonRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<BaoCaoXuatNhapTonDto>> BaoCaoXuatNhapTon(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin)
        {
            var result = await _repo.BaoCaoXuatNhapTon(startDate, endDate, userKhoId, isAdmin);
            // TÍNH CUỐI KỲ
            foreach (var item in result)
            {
                item.SL_Cuoi_Ky =
                    item.SL_Dau_Ky +
                    item.SL_Nhap -
                    item.SL_Xuat;
            }
            return result;
        }
    }
}
