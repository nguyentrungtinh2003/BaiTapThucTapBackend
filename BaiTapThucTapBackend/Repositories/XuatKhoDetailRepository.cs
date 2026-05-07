using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories
{
    public class XuatKhoDetailRepository : IXuatKhoDetailRepository
    {
        private readonly AppDbcontext _context;

        public XuatKhoDetailRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task Create(XuatKhoDetail entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<XuatKhoDetail> GetById(int id) => await _context.XuatKhoChiTiets.FindAsync(id);
        public async Task Update(XuatKhoDetail entity)
        {
            _context.XuatKhoChiTiets.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(XuatKhoDetail entity)
        {
            _context.XuatKhoChiTiets.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
