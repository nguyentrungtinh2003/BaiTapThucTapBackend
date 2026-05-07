using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class XNKXuatKhoRepository : IXNKXuatKhoRepository
    {
        private readonly AppDbcontext _context;

        public XNKXuatKhoRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<XNKXuatKho>> GetAll() => await _context.XNKXuatKhos
            .Include(x => x.Kho)
            .Include(x => x.ChiTiets).ToListAsync();

        public async Task<bool> ExistsSoPhieu(string sophieu)
        {
            return await _context.XNKXuatKhos.AnyAsync(x => x.So_Phieu_Xuat_Kho == sophieu);
        }

        public async Task Add(XNKXuatKho entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public async Task Update(XNKXuatKho entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<XNKXuatKho?> GetBySoPhieuAsync(string soPhieu)
        => await _context.XNKXuatKhos.FirstOrDefaultAsync(x => x.So_Phieu_Xuat_Kho == soPhieu);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
