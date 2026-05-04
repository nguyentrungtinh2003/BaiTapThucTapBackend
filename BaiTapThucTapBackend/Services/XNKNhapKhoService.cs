using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class XNKNhapKhoService : IXNKNhapKhoService
    {
        private readonly IXNKNhapKhoRepository _repo;

        public XNKNhapKhoService(IXNKNhapKhoRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> HandleAdjustmentAsync(XNKNhapKho model)
        {
            if (string.IsNullOrEmpty(model.So_Phieu_Nhap_Kho))
            {
                throw new Exception("So phieu nhap kho khong duoc rong");
            }

            if(model.Kho_ID <= 0)
            {
                throw new Exception("Kho khong duoc rong");
            }

            var existing = await _repo.GetBySoPhieuAsync(model.So_Phieu_Nhap_Kho);

            if(existing == null)
            {
                await _repo.Add(model);
            }
            else
            {
                // Nếu đã có, cập nhật thông tin Header mới
                existing.Kho_ID = model.Kho_ID;
                existing.NCC_ID = model.NCC_ID;
                existing.Ngay_Nhap_Kho = model.Ngay_Nhap_Kho;
                existing.Ghi_Chu = model.Ghi_Chu;

                await _repo.Update(existing);
            }

            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
