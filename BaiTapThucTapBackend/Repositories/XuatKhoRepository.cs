using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class XuatKhoRepository : IXuatKhoRepository
    {
        private readonly AppDbcontext _context;
        private readonly NormalizeService _normalizeService;

        public XuatKhoRepository(AppDbcontext context, NormalizeService normalizeService)
        {
            _context = context;
            _normalizeService = normalizeService;
        }

        public async Task<List<XuatKho>> GetAll() => await _context.XuatKhos.
            Include(x => x.Kho)
            .Include(x => x.ChiTiets).ToListAsync();

        public async Task<XuatKho> GetById(int id) => await _context.XuatKhos.Include(x => x.ChiTiets).FirstAsync(x => x.Id == id);

        public async Task<bool> ExistsSoPhieu(string sophieu)
        {
            return await _context.XuatKhos.AnyAsync(x => x.So_Phieu_Xuat_Kho.ToLower() == _normalizeService.Normalize(sophieu).ToLower());
         
        }

        public async Task Add(XuatKho entity)
        {
            _context.XuatKhos.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(XuatKho entity)
        {
            _context.XuatKhos.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<List<BaoCaoXuatKhoDto>> BaoCaoChiTietHangXuat(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin)
        {
            var query = _context.XuatKhoChiTiets
          .Include(x => x.SanPham)

          .Join(
              _context.XNKXuatKhos
                  .Include(x => x.Kho)
                  .Where(x => x.IsLatest),

              detail => detail.Xuat_Kho_ID,
              header => header.Xuat_Kho_ID,

              (detail, header) => new
              {
                  Detail = detail,
                  Header = header
              }
          )

          .Where(x =>
              x.Header.Ngay_Xuat_Kho >= startDate.Date &&
              x.Header.Ngay_Xuat_Kho < endDate.Date.AddDays(1)
          );

            // USER -> chỉ xem kho của mình
            if (!isAdmin)
            {
                query = query.Where(x => x.Header.Kho.Id == userKhoId);
            }


            return await query.Select(x => new BaoCaoXuatKhoDto
            {
                Ngay_Xuat = x.Header.Ngay_Xuat_Kho,

                So_Phieu_Xuat_Kho = x.Header.So_Phieu_Xuat_Kho,

                Ma_San_Pham = x.Detail.SanPham.Ma_San_Pham,

                Ten_San_Pham = x.Detail.SanPham.Ten_San_Pham,

                SL_Xuat = x.Detail.SL_Xuat,

                Don_Gia_Xuat = x.Detail.Don_Gia_Xuat,

            }).ToListAsync();
        }
    }
}
