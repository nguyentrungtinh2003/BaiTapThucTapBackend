using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Services
{
    public class XNKNhapKhoService : IXNKNhapKhoService
    {
        private readonly IXNKNhapKhoRepository _repoxnk;
        private readonly INhapKhoRepository _repo;
        private readonly AppDbcontext _context;

        public XNKNhapKhoService(IXNKNhapKhoRepository repoxnk,INhapKhoRepository repo, AppDbcontext context)
        {
            _repoxnk = repoxnk;
            _repo = repo;
            _context = context;
        }

        public async Task<bool> HandleAdjustmentAsync(CreateXNKNhapKhoRequest model)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. VALIDATE
                if (string.IsNullOrEmpty(model.So_Phieu_Nhap_Kho))
                    throw new Exception("Số phiếu nhập kho không được rỗng");

                if (model.Kho_ID <= 0)
                    throw new Exception("Kho không được rỗng");

                if (model.NCC_ID <= 0)
                    throw new Exception("Nhà cung cấp không được rỗng");

                // check tồn tại
                var nhapKho = await _repo.GetById(model.Id);
                if (nhapKho == null)
                    throw new Exception("Không tìm thấy phiếu nhập");

                // check unique
                var isExist = await _context.XNKNhapKhos
                    .AnyAsync(x => x.So_Phieu_Nhap_Kho == model.So_Phieu_Nhap_Kho
                                && x.Nhap_Kho_ID != model.Id);

                if (isExist)
                    throw new Exception("Số phiếu đã tồn tại");

                // lấy bản hiện tại
                var latest = await _context.XNKNhapKhos
                    .Where(x => x.Nhap_Kho_ID == model.Id && x.IsLatest)
                    .FirstOrDefaultAsync();

                // version
                int newVersion = (latest?.Version ?? 0) + 1;

                // tắt bản cũ
                if (latest != null)
                {
                    latest.IsLatest = false;
                }

                // insert mới
                var log = new XNKNhapKho
                {
                    Nhap_Kho_ID = model.Id,
                    So_Phieu_Nhap_Kho = model.So_Phieu_Nhap_Kho,
                    Kho_ID = model.Kho_ID,
                    NCC_ID = model.NCC_ID,
                    Ngay_Nhap_Kho = model.Ngay_Nhap_Kho,
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
