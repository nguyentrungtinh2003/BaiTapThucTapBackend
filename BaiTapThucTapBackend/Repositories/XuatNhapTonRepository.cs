using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class XuatNhapTonRepository : IXuatNhapTonRepository
    {
        private readonly AppDbcontext _context;
        public XuatNhapTonRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<BaoCaoXuatNhapTonDto>> BaoCaoXuatNhapTon
 (
     DateTime startDate,
     DateTime endDate,
     int userKhoId,
     bool isAdmin
 )
        {
            var result = await _context.SanPhams
                .Select(sp => new BaoCaoXuatNhapTonDto
                {
                    Ma_San_Pham = sp.Ma_San_Pham,

                    Ten_San_Pham = sp.Ten_San_Pham,

                    // =========================
                    // TỒN ĐẦU KỲ
                    // =========================

                    SL_Dau_Ky =

                        (
                            _context.NhapKhoChiTiets
                                .Where(nk =>
                                    nk.San_Pham_ID == sp.Id &&

                                    nk.NhapKho.Ngay_Nhap_Kho < startDate &&

                                    (
                                        isAdmin ||
                                        nk.NhapKho.Kho_ID == userKhoId
                                    )
                                )
                                .Sum(nk => (int?)nk.SL_Nhap) ?? 0
                        )

                        -

                        (
                            _context.XuatKhoChiTiets
                                .Where(xk =>
                                    xk.San_Pham_ID == sp.Id &&

                                    xk.XuatKho.Ngay_Xuat_Kho < startDate &&

                                    (
                                        isAdmin ||
                                        xk.XuatKho.Kho.Id == userKhoId
                                    )
                                )
                                .Sum(xk => (int?)xk.SL_Xuat) ?? 0
                        ),

                    // =========================
                    // NHẬP TRONG KỲ
                    // =========================

                    SL_Nhap =

                        _context.NhapKhoChiTiets
                            .Where(nk =>
                                nk.San_Pham_ID == sp.Id &&

                                nk.NhapKho.Ngay_Nhap_Kho >= startDate &&

                                nk.NhapKho.Ngay_Nhap_Kho < endDate.AddDays(1) &&

                                (
                                    isAdmin ||
                                    nk.NhapKho.Kho_ID == userKhoId
                                )
                            )
                            .Sum(nk => (int?)nk.SL_Nhap) ?? 0,

                    // =========================
                    // XUẤT TRONG KỲ
                    // =========================

                    SL_Xuat =

                        _context.XuatKhoChiTiets
                            .Where(xk =>
                                xk.San_Pham_ID == sp.Id &&

                                xk.XuatKho.Ngay_Xuat_Kho >= startDate &&

                                xk.XuatKho.Ngay_Xuat_Kho < endDate.AddDays(1) &&

                                (
                                    isAdmin ||
                                    xk.XuatKho.Kho.Id == userKhoId
                                )
                            )
                            .Sum(xk => (int?)xk.SL_Xuat) ?? 0
                })

                .ToListAsync();

            //// TỒN CUỐI KỲ
            //foreach (var item in result)
            //{
            //    item.SL_Cuoi_Ky =
            //        item.SL_Dau_Ky +
            //        item.SL_Nhap -
            //        item.SL_Xuat;
            //}

            return result;
        }
    }
}
