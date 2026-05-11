using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class LoaiSanPhamRepository : ILoaiSanPhamRepository
    {
        private readonly AppDbcontext _context;
        private readonly NormalizeService _normalizeService;
        public LoaiSanPhamRepository(AppDbcontext context,NormalizeService normalizeService)
        {
            _context = context;
            _normalizeService = normalizeService;
        }

        public async Task<List<LoaiSanPham>> GetAll() => await _context.LoaiSanPhams.ToListAsync();
        public async Task<LoaiSanPham> GetById(int id) => await _context.LoaiSanPhams.FindAsync(id);

        public async Task Add(LoaiSanPham entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(LoaiSanPham entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(LoaiSanPham entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsMa(string ma) => await _context.LoaiSanPhams.AnyAsync(x => x.Ma_LSP.ToLower() == _normalizeService.Normalize(ma).ToLower());
        public async Task<bool> ExistsTen(string ten) => await _context.LoaiSanPhams.AnyAsync(x => x.Ten_LSP.ToLower() == _normalizeService.Normalize(ten).ToLower());
    }
}
