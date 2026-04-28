using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class DonViTinhRepository : IDonViTinhRepository
    {
        private readonly AppDbcontext _context;
        public DonViTinhRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<DonViTinh>> GetAll() => await _context.DonViTinhs.ToListAsync();
        public async Task<DonViTinh> GetById(int id) => await _context.DonViTinhs.FindAsync(id);

        public async Task Add(DonViTinh entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(DonViTinh entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(DonViTinh entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> Exists(string ten) => await _context.DonViTinhs.AnyAsync(x => x.Ten_Don_Vi_Tinh == ten);
    }
}
