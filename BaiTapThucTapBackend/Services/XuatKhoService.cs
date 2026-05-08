using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Services
{
    public class XuatKhoService : IXuatKhoService
    {
        private readonly IXuatKhoRepository _repo;
        private readonly IXuatKhoDetailRepository _repodetail;
        private readonly IXNKXuatKhoRepository _xnkrepo;
        private readonly AppDbcontext _context;

        public XuatKhoService(IXuatKhoRepository repo, AppDbcontext context, IXNKXuatKhoRepository xnkrepo, IXuatKhoDetailRepository repodetail)
        {
            _repo = repo;
            _context = context;
            _xnkrepo = xnkrepo;
            _repodetail = repodetail;
        }

        // 🔥 Lấy dữ liệu HIỂN THỊ → từ XNK (IsLatest)
        public async Task<List<XuatKhoDto>> GetAll(int userKhoId, bool isAdmin)
        {
            var query = _context.XNKXuatKhos
                .Where(x => x.IsLatest)
                .Include(x => x.Kho)
                .AsQueryable();

            // USER -> chỉ xem kho của mình
            if (!isAdmin)
            {
                query = query.Where(x => x.Kho_ID == userKhoId);
            }

            var headers = await query.ToListAsync();

            // lấy id phiếu xuất
            var xuatKhoIds = headers
                .Select(x => x.Xuat_Kho_ID)
                .ToList();

            // chỉ load detail liên quan
            var details = await _context.XuatKhoChiTiets
                .Where(x => xuatKhoIds.Contains(x.Xuat_Kho_ID))
                .ToListAsync();

            var result = headers.Select(x => new XuatKhoDto
            {
                Id = x.Xuat_Kho_ID,

                So_Phieu_Xuat_Kho = x.So_Phieu_Xuat_Kho,

                Kho_ID = x.Kho_ID,

                Ten_Kho = x.Kho?.Ten_Kho,

                Ngay_Xuat_Kho = x.Ngay_Xuat_Kho,

                Ghi_Chu = x.Ghi_Chu,

                ChiTiets = details
                    .Where(d => d.Xuat_Kho_ID == x.Xuat_Kho_ID)
                    .Select(d => new XuatKhoDetailDto
                    {
                        Id = d.Id,

                        Xuat_Kho_ID = d.Xuat_Kho_ID,

                        San_Pham_ID = d.San_Pham_ID,

                        SL_Xuat = d.SL_Xuat,

                        Don_Gia_Xuat = d.Don_Gia_Xuat

                    }).ToList()

            }).ToList();

            return result;
        }
        // print
        public async Task<XuatKhoDto> GetById(int id)
        {
            var header = await _context.XNKXuatKhos
                .Where(x => x.IsLatest && x.Xuat_Kho_ID == id)
                .Include(x => x.Kho)
                .FirstOrDefaultAsync();

            if (header == null) return null;

            var details = await _context.XuatKhoChiTiets
                .Where(d => d.Xuat_Kho_ID == header.Xuat_Kho_ID).Include(d => d.SanPham)
        .ThenInclude(sp => sp.DonViTinh)
                .ToListAsync();

            var result = new XuatKhoDto
            {
                Id = header.Xuat_Kho_ID,
                So_Phieu_Xuat_Kho = header.So_Phieu_Xuat_Kho,
                Kho_ID = header.Kho_ID,
                Ten_Kho = header.Kho?.Ten_Kho,
                Ngay_Xuat_Kho = header.Ngay_Xuat_Kho,
                Ghi_Chu = header.Ghi_Chu,

                ChiTiets = details.Select(d => new XuatKhoDetailDto
                {
                    Id = d.Id,
                    Xuat_Kho_ID = d.Xuat_Kho_ID,
                    San_Pham_ID = d.San_Pham_ID,
                    Ma_San_Pham = d.SanPham?.Ma_San_Pham,
                    Ten_San_Pham = d.SanPham.Ten_San_Pham,
                    Ten_Don_Vi_Tinh = d.SanPham?.DonViTinh?.Ten_Don_Vi_Tinh,
                    SL_Xuat = d.SL_Xuat,
                    Don_Gia_Xuat = d.Don_Gia_Xuat
                }).ToList()
            };

            return result;
        }
        public async Task<XuatKhoDto> Create(CreateXuatKhoRequest request)
        {
            // 🔥 VALIDATE
            if (string.IsNullOrEmpty(request.So_Phieu_Xuat_Kho?.Trim()))
                throw new Exception("Số phiếu xuất kho không được rỗng");

            if (request.Kho_ID <= 0)
                throw new Exception("Kho không hợp lệ");

            if (request.Ngay_Xuat_Kho == default)
                throw new Exception("Ngày xuất kho không hợp lệ");

            var exists = await _repo.ExistsSoPhieu(request.So_Phieu_Xuat_Kho);
            if (exists)
                throw new Exception("Số phiếu xuất kho đã tồn tại");

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 🟦 1. INSERT bảng gốc
                var entity = XuatKhoMapping.ToEntity(request);
                await _repo.Add(entity);
                await _context.SaveChangesAsync(); // 🔥 để có Id

                // 🟨 2. INSERT XNK version 1
                var log = new XNKXuatKho
                {
                    Xuat_Kho_ID = entity.Id,
                    So_Phieu_Xuat_Kho = entity.So_Phieu_Xuat_Kho.Trim(),
                    Kho_ID = entity.Kho_ID,
                    Ngay_Xuat_Kho = entity.Ngay_Xuat_Kho,
                    Ghi_Chu = entity.Ghi_Chu,

                    Version = 1,
                    IsLatest = true,
                    Updated_At = DateTime.UtcNow
                };

                await _xnkrepo.Add(log);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return XuatKhoMapping.ToDto(entity);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateDetails(int id, XuatKhoDetailDto entity)
        {
            var item = await _context.XuatKhoChiTiets.FindAsync(id);
            if (item == null)
            {
                throw new Exception("Không tìm thấy");
            }

            item.SL_Xuat = entity.SL_Xuat;
            item.Don_Gia_Xuat = entity.Don_Gia_Xuat;

            await _repodetail.Update(item);
        }
        public async Task Delete(int id)
        {
            var exists = await _repo.GetById(id);
            if (exists == null)
            {
                throw new Exception("Không tìm thấy");
            }
            await _repo.Delete(exists);
        }
        public async Task<List<BaoCaoXuatKhoDto>> BaoCaoChiTietHangXuat(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin)
            => await _repo.BaoCaoChiTietHangXuat(startDate, endDate, userKhoId, isAdmin);
    }
}
