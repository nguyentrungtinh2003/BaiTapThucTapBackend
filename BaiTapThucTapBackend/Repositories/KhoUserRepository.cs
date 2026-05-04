using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class KhoUserRepository : IKhoUserRepository
    {
        private readonly AppDbcontext _context;

        public KhoUserRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<KhoUser>> GetAll() => await _context.KhoUsers.ToListAsync();

        public async Task<KhoUser> Get(string MaDangNhap, int KhoID) => await _context.KhoUsers.FirstOrDefaultAsync(x => x.Ma_Dang_Nhap == MaDangNhap && x.Kho_ID == KhoID);

        public async Task<bool> Exists(string MaDangNhap, int KhoID) => await _context.KhoUsers.AnyAsync(x => x.Ma_Dang_Nhap == MaDangNhap && x.Kho_ID == KhoID);
        
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
    }
}
