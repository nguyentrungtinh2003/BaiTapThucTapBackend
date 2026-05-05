using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class XNKNhapKhoDetailRepository : IXNKNhapKhoDetailRepository
    {
        private readonly AppDbcontext _context;
        public XNKNhapKhoDetailRepository(AppDbcontext context) => _context = context;

        public async Task<List<XNKNhapKhoDetail>> GetByHeaderIdAsync(int maNhapKho)
            => await _context.XNKNhapKhoChiTiets.Where(x => x.XNKNhap_Kho_ID == maNhapKho).ToListAsync();

        public async Task ClearDetailsByHeaderIdAsync(int headerId)
        {
            var oldDetails = _context.XNKNhapKhoChiTiets.Where(x => x.XNKNhap_Kho_ID == headerId);
            _context.XNKNhapKhoChiTiets.RemoveRange(oldDetails);
        }

        public async Task AddRangeAsync(List<XNKNhapKhoDetail> details)
            => await _context.XNKNhapKhoChiTiets.AddRangeAsync(details);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
