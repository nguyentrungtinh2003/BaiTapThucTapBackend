using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class NhaCungCapRepository : INhaCungCapRepository
    {
        private readonly AppDbcontext _context;
        private readonly NormalizeService _normalizeService;
        public NhaCungCapRepository(AppDbcontext context,NormalizeService normalizeService)
        {
            _context = context;
            _normalizeService = normalizeService;
        }

        public async Task<List<NhaCungCap>> GetAll() => await _context.NhaCungCaps.ToListAsync();

        public async Task<NhaCungCap> GetById(int id) => await _context.NhaCungCaps.FindAsync(id);

        public async Task Add(NhaCungCap entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(NhaCungCap entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(NhaCungCap entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsMa(string ma) => await _context.NhaCungCaps.AnyAsync(x => x.Ma_NCC.ToLower() == _normalizeService.Normalize(ma).ToLower());
        public async Task<bool> ExistsTen(string ten) => await _context.NhaCungCaps.AnyAsync(x => x.Ten_NCC.ToLower() == _normalizeService.Normalize(ten).ToLower());
    }
}
