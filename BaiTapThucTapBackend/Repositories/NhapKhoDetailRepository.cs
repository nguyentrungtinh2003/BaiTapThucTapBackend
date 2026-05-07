using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;

namespace BaiTapThucTapBackend.Repositories
{
	public class NhapKhoDetailRepository : INhapKhoDetailRepository
	{
		private readonly AppDbcontext _context;

		public NhapKhoDetailRepository(AppDbcontext context)
		{
			_context = context;
		}

		public async Task Create(NhapKhoDetail entity)
		{
			_context.Add(entity);
			await _context.SaveChangesAsync();
		}
		public async Task<NhapKhoDetail> GetById(int id) => await _context.NhapKhoChiTiets.FindAsync(id);
		public async Task Update (NhapKhoDetail entity)
		{
			_context.NhapKhoChiTiets.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete (NhapKhoDetail entity)
		{
			_context.NhapKhoChiTiets.Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}
