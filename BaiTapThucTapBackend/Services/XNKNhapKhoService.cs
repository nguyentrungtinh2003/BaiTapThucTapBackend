using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Mappings;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

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

                // 2. GET HEADER (tracked entity)
                var nhapKho = await _repo.GetById(model.Id);

                if (nhapKho == null)
                    throw new Exception("Không tìm thấy phiếu nhập");

                // 3. UPDATE HEADER
                nhapKho.So_Phieu_Nhap_Kho = model.So_Phieu_Nhap_Kho;
                nhapKho.Kho_ID = model.Kho_ID;
                nhapKho.NCC_ID = model.NCC_ID;
                nhapKho.Ngay_Nhap_Kho = model.Ngay_Nhap_Kho;
                nhapKho.Ghi_Chu = model.Ghi_Chu;

                // 4. UPDATE DETAIL (replace full)
                await _repo.DeleteDetails(model.Id);

                if (model.ChiTiets != null && model.ChiTiets.Any())
                {
                    foreach (var ct in model.ChiTiets)
                    {
                        await _repo.AddDetail(new NhapKhoDetail
                        {
                            Nhap_Kho_ID = model.Id,
                            San_Pham_ID = ct.San_Pham_ID,
                            SL_Nhap = ct.SL_Nhap,
                            Don_Gia_Nhap = ct.Don_Gia_Nhap
                        });
                    }
                }

                // 5. LOG (INSERT ONLY - KHÔNG UPDATE)
                var log = new XNKNhapKho
                {
                    So_Phieu_Nhap_Kho = model.So_Phieu_Nhap_Kho,
                    Kho_ID = model.Kho_ID,
                    NCC_ID = model.NCC_ID,
                    Ngay_Nhap_Kho = model.Ngay_Nhap_Kho,
                    Ghi_Chu = model.Ghi_Chu,
                };

                await _repoxnk.Add(log);

                // 6. SAVE ALL
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
