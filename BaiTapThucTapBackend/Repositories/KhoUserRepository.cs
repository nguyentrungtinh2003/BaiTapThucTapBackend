using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class KhoUserRepository : IKhoUserRepository
    {
        private readonly AppDbcontext _context;
        private readonly NormalizeService _normalizeService;

        public KhoUserRepository(AppDbcontext context,NormalizeService normalizeService)
        {
            _context = context;
            _normalizeService = normalizeService;
        }

        public async Task<List<KhoUser>> GetAll() => await _context.KhoUsers.Include(x => x.Kho).ToListAsync();

        public async Task<KhoUser> Get(string MaDangNhap, int KhoID) => await _context.KhoUsers.FirstOrDefaultAsync(x => x.Ma_Dang_Nhap == MaDangNhap && x.Kho_ID == KhoID);

        public async Task<bool> Exists(string MaDangNhap, int KhoID) => await _context.KhoUsers.AnyAsync(x => x.Ma_Dang_Nhap.ToLower() == _normalizeService.Normalize(MaDangNhap).ToLower() && x.Kho_ID == KhoID);
        
        public async Task Add(KhoUser entity)
        {
            _context.KhoUsers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(KhoUser entity)
        {
            _context.KhoUsers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<KhoUser>> GetByUser(string Ma_Dang_Nhap)
        {
            return await _context.KhoUsers.Include(x => x.Kho)
                 .Where(x => x.Ma_Dang_Nhap == Ma_Dang_Nhap).ToListAsync();
        }

        public async Task<KhoUser?> GetByKey(string Ma_Dang_Nhap, int Kho_ID)
        {
            return await _context.KhoUsers.FirstOrDefaultAsync(x => x.Ma_Dang_Nhap == Ma_Dang_Nhap && x.Kho_ID == Kho_ID);
        }
    }
}
