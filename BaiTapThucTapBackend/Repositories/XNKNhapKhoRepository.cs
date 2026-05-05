using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class XNKNhapKhoRepository : IXNKNhapKhoRepository
    {
        private readonly AppDbcontext _context;

        public XNKNhapKhoRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<XNKNhapKho>> GetAll() => await _context.XNKNhapKhos
            .Include(x => x.NhaCungCap)
            .Include(x => x.Kho)
            .Include(x => x.ChiTiets).ToListAsync();

        public async Task<bool> ExistsSoPhieu(string sophieu)
        {
            return await _context.XNKNhapKhos.AnyAsync(x => x.So_Phieu_Nhap_Kho == sophieu);
        }

        public async Task Add(XNKNhapKho entity)
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

        public async Task Update(XNKNhapKho entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<XNKNhapKho?> GetBySoPhieuAsync(string soPhieu)
        => await _context.XNKNhapKhos.FirstOrDefaultAsync(x => x.So_Phieu_Nhap_Kho == soPhieu);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
