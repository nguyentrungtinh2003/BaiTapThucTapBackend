using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace BaiTapThucTapBackend.Repositories
{
    public class KhoRepository : IKhoRepository
    {
        private readonly AppDbcontext _context;
        public KhoRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<Kho>> GetAll() => await _context.Khos.ToListAsync();
        public async Task<Kho> GetById(int id) => await _context.Khos.FindAsync(id);

        public async Task Add(Kho entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Kho entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Kho entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsTen(string ten) => await _context.Khos.AnyAsync(x => x.Ten_Kho == ten);
    }
}
