using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class NhapKhoRepository : INhapKhoRepository
    {
        private readonly AppDbcontext _context;

        public NhapKhoRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<NhapKho>> GetAll() => await _context.NhapKhos.Include(x => x.Details).ToListAsync();
        public async Task<NhapKho> GetById(int id) => await _context.NhapKhos.Include(x => x.Details).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> ExistsSoPhieu(string sophieu)
        {
            return await _context.NhapKhos.AnyAsync(x => x.So_Phieu_Nhap_Kho == sophieu);
        }

        public async Task Add(NhapKho entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(NhapKho entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
