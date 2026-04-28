using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class NhaCungCapRepository : INhaCungCapRepository
    {
        private readonly AppDbcontext _context;
        public NhaCungCapRepository(AppDbcontext context)
        {
            _context = context;
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
    }
}
