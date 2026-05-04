using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class XuatKhoRepository : IXuatKhoRepository
    {
        private readonly AppDbcontext _context;

        public XuatKhoRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<XuatKho>> GetAll() => await _context.XuatKhos.Include(x => x.ChiTiets).ToListAsync();

        public async Task<XuatKho> GetById(int id) => await _context.XuatKhos.Include(x => x.ChiTiets).FirstAsync(x => x.Id == id);

        public async Task<bool> ExistsSoPhieu(string sophieu)
        {
            return await _context.XuatKhos.AnyAsync(x => x.So_Phieu_Xuat_Kho == sophieu);
         
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
    }
}
