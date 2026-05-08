using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BaiTapThucTapBackend.Services
{
	public class NhapKhoService : INhapKhoService
	{
		private readonly INhapKhoRepository _repo;
		private readonly INhapKhoDetailRepository _repodetail;
		private readonly IXNKNhapKhoRepository _xnkrepo;
		private readonly AppDbcontext _context;

		public NhapKhoService(
			INhapKhoRepository repo,
			AppDbcontext context,
			IXNKNhapKhoRepository xnkrepo,
			INhapKhoDetailRepository repodetail)
		{
			_repo = repo;
			_context = context;
			_xnkrepo = xnkrepo;
			_repodetail = repodetail;
		}

		// 🔥 Lấy dữ liệu HIỂN THỊ → từ XNK (IsLatest)
		public async Task<List<NhapKhoDto>> GetAll(int userKhoId, bool isAdmin)
		{
            // admin
            var query = _context.XNKNhapKhos
          .Where(x => x.IsLatest)
          .Include(x => x.Kho)
          .Include(x => x.NhaCungCap)
          .AsQueryable();

            // USER -> chỉ xem kho của mình
            if (!isAdmin)
            {
                query = query.Where(x => x.Kho_ID == userKhoId);
            }

            var headers = await query.ToListAsync();

            var details = await _context.NhapKhoChiTiets
                .ToListAsync();

            var result = headers.Select(x => new NhapKhoDto
            {
                Id = x.Nhap_Kho_ID,

                So_Phieu_Nhap_Kho = x.So_Phieu_Nhap_Kho,

                Kho_ID = x.Kho_ID,

                Ten_Kho = x.Kho?.Ten_Kho,

                NCC_ID = x.NCC_ID,

                Ten_NCC = x.NhaCungCap?.Ten_NCC,

                Ngay_Nhap_Kho = x.Ngay_Nhap_Kho,

                Ghi_Chu = x.Ghi_Chu,

                ChiTiets = details
                    .Where(d => d.Nhap_Kho_ID == x.Nhap_Kho_ID)
                    .Select(d => new NhapKhoDetailDto
                    {
                        Id = d.Id,

                        Nhap_Kho_ID = d.Nhap_Kho_ID,

                        San_Pham_ID = d.San_Pham_ID,

                        SL_Nhap = d.SL_Nhap,

                        Don_Gia_Nhap = d.Don_Gia_Nhap
                    })
                    .ToList()

            }).ToList();

            return result;
        }
		// print
        public async Task<NhapKhoDto> GetById(int id)
        {
            var header = await _context.XNKNhapKhos
                .Where(x => x.IsLatest && x.Nhap_Kho_ID == id)
                .Include(x => x.Kho)
                .Include(x => x.NhaCungCap)
                .FirstOrDefaultAsync();

            if (header == null) return null;

            var details = await _context.NhapKhoChiTiets
                .Where(d => d.Nhap_Kho_ID == header.Nhap_Kho_ID).Include(d => d.SanPham)
        .ThenInclude(sp => sp.DonViTinh)
                .ToListAsync();

            var result = new NhapKhoDto
            {
                Id = header.Nhap_Kho_ID,
                So_Phieu_Nhap_Kho = header.So_Phieu_Nhap_Kho,
                Kho_ID = header.Kho_ID,
                Ten_Kho = header.Kho?.Ten_Kho,
                NCC_ID = header.NCC_ID,
                Ten_NCC = header.NhaCungCap?.Ten_NCC,
                Ngay_Nhap_Kho = header.Ngay_Nhap_Kho,
                Ghi_Chu = header.Ghi_Chu,

                ChiTiets = details.Select(d => new NhapKhoDetailDto
                {
                    Id = d.Id,
                    Nhap_Kho_ID = d.Nhap_Kho_ID,
                    San_Pham_ID = d.San_Pham_ID,
                    Ma_San_Pham = d.SanPham?.Ma_San_Pham,
                    Ten_San_Pham = d.SanPham.Ten_San_Pham,
                    Ten_Don_Vi_Tinh = d.SanPham?.DonViTinh?.Ten_Don_Vi_Tinh,
                    SL_Nhap = d.SL_Nhap,
                    Don_Gia_Nhap = d.Don_Gia_Nhap
                }).ToList()
            };

            return result;
        }
        public async Task<NhapKhoDto> Create(CreateNhapKhoRequest request)
		{
			// 🔥 VALIDATE
			if (string.IsNullOrEmpty(request.So_Phieu_Nhap_Kho?.Trim()))
				throw new Exception("Số phiếu nhập kho không được rỗng");

			if (request.Kho_ID <= 0)
				throw new Exception("Kho không hợp lệ");

			if (request.NCC_ID <= 0)
				throw new Exception("Nhà cung cấp không hợp lệ");

			if (request.Ngay_Nhap_Kho == default)
				throw new Exception("Ngày nhập kho không hợp lệ");

			var exists = await _repo.ExistsSoPhieu(request.So_Phieu_Nhap_Kho);
			if (exists)
				throw new Exception("Số phiếu nhập kho đã tồn tại");

			await using var transaction = await _context.Database.BeginTransactionAsync();

			try
			{
				// 🟦 1. INSERT bảng gốc
				var entity = NhapKhoMapping.ToEntity(request);
				await _repo.Add(entity);
				await _context.SaveChangesAsync(); // 🔥 để có Id

				// 🟨 2. INSERT XNK version 1
				var log = new XNKNhapKho
				{
					Nhap_Kho_ID = entity.Id,
					So_Phieu_Nhap_Kho = entity.So_Phieu_Nhap_Kho.Trim(),
					Kho_ID = entity.Kho_ID,
					NCC_ID = entity.NCC_ID,
					Ngay_Nhap_Kho = entity.Ngay_Nhap_Kho,
					Ghi_Chu = entity.Ghi_Chu,

					Version = 1,
					IsLatest = true,
					Updated_At = DateTime.UtcNow
				};

				await _xnkrepo.Add(log);
				await _context.SaveChangesAsync();

				await transaction.CommitAsync();

				return NhapKhoMapping.ToDto(entity);
			}
			catch
			{
				await transaction.RollbackAsync();
				throw;
			}
		}

		public async Task UpdateDetails(int id,NhapKhoDetailDto entity)
		{
			var item = await _context.NhapKhoChiTiets.FindAsync(id);
			if(item == null)
			{
				throw new Exception("Khong tim thay");
			}

			item.SL_Nhap = entity.SL_Nhap;
			item.Don_Gia_Nhap = entity.Don_Gia_Nhap;

			await _repodetail.Update(item);
		}
		public async Task Delete(int id)
		{
			var entity = await _repo.GetById(id);

			if (entity == null)
				throw new Exception("Không tìm thấy nhập kho");

			await _repo.Delete(entity);
		}

		public async Task<List<BaoCaoNhapKhoDto>> BaoCaoChiTietHangNhap(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin)
			=> await _repo.BaoCaoChiTietHangNhap(startDate, endDate, userKhoId, isAdmin);
		
	}
}