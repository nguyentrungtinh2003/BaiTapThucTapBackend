using BaiTapThucTapBackend.Controllers;
using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Migrations;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class NhapKhoRepository : INhapKhoRepository
    {
        private readonly AppDbcontext _context;
        private readonly NormalizeService _normalizeService;

        public NhapKhoRepository(AppDbcontext context,NormalizeService normalizeService)
        {
            _context = context;
            _normalizeService = normalizeService;
        }

        public async Task<List<NhapKho>> GetAll() => await _context.NhapKhos
            .Include(x => x.NhaCungCap)
            .Include(x => x.Kho)
            .Include(x => x.ChiTiets).ToListAsync();
        public async Task<NhapKho> GetById(int id) => await _context.NhapKhos
            .Include(x => x.Kho)
            .Include(x => x.NhaCungCap)
            .Include(x => x.ChiTiets).ThenInclude(ct => ct.SanPham).ThenInclude(sp => sp.DonViTinh).FirstAsync(x => x.Id == id);

        public async Task<bool> ExistsSoPhieu(string sophieu)
        {
            return await _context.NhapKhos.AnyAsync(x => x.So_Phieu_Nhap_Kho.ToLower() == _normalizeService.Normalize(sophieu).ToLower());
        }

        public async Task Add(NhapKho entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddDetail(NhapKhoDetail detail)
        {
            await _context.NhapKhoChiTiets.AddAsync(detail);
        }
        public async Task DeleteDetails(int nhapKhoId)
        {
            var details = _context.NhapKhoChiTiets
                .Where(x => x.Nhap_Kho_ID == nhapKhoId);

            _context.NhapKhoChiTiets.RemoveRange(details);
        }
        public async Task Update(NhapKho entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(NhapKho entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BaoCaoNhapKhoDto>> BaoCaoChiTietHangNhap(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin)
        {
            var query = _context.NhapKhoChiTiets
         .Include(x => x.SanPham)

         .Join(
             _context.XNKNhapKhos
                 .Include(x => x.NhaCungCap)
                 .Include(x => x.Kho)
                 .Where(x => x.IsLatest),

             detail => detail.Nhap_Kho_ID,
             header => header.Nhap_Kho_ID,

             (detail, header) => new
             {
                 Detail = detail,
                 Header = header
             }
         )

         .Where(x =>
             x.Header.Ngay_Nhap_Kho >= startDate.Date &&
             x.Header.Ngay_Nhap_Kho < endDate.Date.AddDays(1)
         );
            // USER -> chỉ xem kho của mình
            if (!isAdmin)
            {
                query = query.Where(x => x.Header.Kho.Id == userKhoId);
            }

            return await query.Select(x => new BaoCaoNhapKhoDto
                     {
                         Ngay_Nhap = x.Header.Ngay_Nhap_Kho,

                         So_Phieu_Nhap_Kho = x.Header.So_Phieu_Nhap_Kho,

                         Ten_NCC = x.Header.NhaCungCap.Ten_NCC,

                         Ma_San_Pham = x.Detail.SanPham.Ma_San_Pham,

                         Ten_San_Pham = x.Detail.SanPham.Ten_San_Pham,

                         SL_Nhap = x.Detail.SL_Nhap,

                         Don_Gia_Nhap = x.Detail.Don_Gia_Nhap,

                     }).ToListAsync();
        }

    }
}
