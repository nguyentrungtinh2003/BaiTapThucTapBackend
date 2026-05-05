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

        public async Task<List<NhapKho>> GetAll() => await _context.NhapKhos
            .Include(x => x.NhaCungCap)
            .Include(x => x.Kho)
            .Include(x => x.ChiTiets).ToListAsync();
        public async Task<NhapKho> GetById(int id) => await _context.NhapKhos.Include(x => x.ChiTiets).FirstAsync(x => x.Id == id);

        public async Task<bool> ExistsSoPhieu(string sophieu)
        {
            return await _context.NhapKhos.AnyAsync(x => x.So_Phieu_Nhap_Kho == sophieu);
        }

        public async Task Add(NhapKho entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddDetail(NhapKhoDetail detail)
        {
            await _context.NhapKhoChiTiets.AddAsync(detail);
        }
        public async Task DeleteDetails(int nhapKhoId)
        {
            var details = _context.NhapKhoChiTiets
                .Where(x => x.Nhap_Kho_ID == nhapKhoId);

            _context.NhapKhoChiTiets.RemoveRange(details);
        }
        public async Task Update(NhapKho entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(NhapKho entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
