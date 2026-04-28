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

        public async Task<KhoUser> Get(int UserID, int KhoID) => await _context.KhoUsers.FirstOrDefaultAsync(x => x.User_ID == UserID && x.Kho_ID == KhoID);

        public async Task<bool> Exists(int User_ID, int KhoID) => await _context.KhoUsers.AnyAsync(x => x.User_ID == User_ID && x.Kho_ID == KhoID);
        
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
