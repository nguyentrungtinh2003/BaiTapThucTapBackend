using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly AppDbcontext _context;

        public SanPhamRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<SanPham>> GetAll() => await _context.SanPhams
            .Include(x => x.LoaiSanPham)
            .Include(x => x.DonViTinh)
            .ToListAsync();

        public async Task<SanPham> GetById(int id) => await _context.SanPhams.FindAsync(id);

        public async Task Add(SanPham entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SanPham entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SanPham entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsMa(string ma) => await _context.SanPhams.AnyAsync(x => x.Ma_San_Pham == ma);
    }
}
