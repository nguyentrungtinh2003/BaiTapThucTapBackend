using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Services
{
    public class XNKXuatKhoService : IXNKXuatKhoService
    {
        private readonly IXNKXuatKhoRepository _repoxnk;
        private readonly IXuatKhoRepository _repo;
        private readonly AppDbcontext _context;

        public XNKXuatKhoService(IXNKXuatKhoRepository repoxnk, IXuatKhoRepository repo, AppDbcontext context)
        {
            _repoxnk = repoxnk;
            _repo = repo;
            _context = context;
        }

        public async Task<bool> HandleAdjustmentAsync(CreateXNKXuatKhoRequest model)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. VALIDATE
                if (string.IsNullOrEmpty(model.So_Phieu_Xuat_Kho))
                    throw new Exception("Số phiếu xuất kho không được rỗng");

                if (model.Kho_ID <= 0)
                    throw new Exception("Kho không được rỗng");

                // check tồn tại
                var xuatKho = await _repo.GetById(model.Id);
                if (xuatKho == null)
                    throw new Exception("Không tìm thấy phiếu xuất");

                // check unique
                var isExist = await _context.XNKXuatKhos
                    .AnyAsync(x => x.So_Phieu_Xuat_Kho == model.So_Phieu_Xuat_Kho
                                && x.Xuat_Kho_ID != model.Id);

                if (isExist)
                    throw new Exception("Số phiếu đã tồn tại");

                // lấy bản hiện tại
                var latest = await _context.XNKXuatKhos
                    .Where(x => x.Xuat_Kho_ID == model.Id && x.IsLatest)
                    .FirstOrDefaultAsync();

                // version
                int newVersion = (latest?.Version ?? 0) + 1;

                // tắt bản cũ
                if (latest != null)
                {
                    latest.IsLatest = false;
                }

                // insert mới
                var log = new XNKXuatKho
                {
                    Xuat_Kho_ID = model.Id,
                    So_Phieu_Xuat_Kho = model.So_Phieu_Xuat_Kho,
                    Kho_ID = model.Kho_ID,
                    Ngay_Xuat_Kho = model.Ngay_Xuat_Kho,
                    Ghi_Chu = model.Ghi_Chu,

                    Version = newVersion,
                    IsLatest = true,
                    Updated_At = DateTime.UtcNow
                };

                await _repoxnk.Add(log);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
