using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class XNKNhapKhoDetailService : IXNKNhapKhoDetailService
    {
        private readonly IXNKNhapKhoDetailRepository _repo;

        public XNKNhapKhoDetailService(IXNKNhapKhoDetailRepository repo) => _repo = repo;

        public async Task<bool> UpdateDetailAdjustmentAsync(int headerId, List<XNKNhapKhoDetail> newDetails)
        {
            try
            {
                // 1. Xóa toàn bộ chi tiết cũ của phiếu XNK này
                await _repo.ClearDetailsByHeaderIdAsync(headerId);

                // 2. Gán Header ID cho các dòng chi tiết mới
                foreach (var item in newDetails)
                {
                    item.Nhap_Kho_ID = headerId;
                    item.Id = 0; // Đảm bảo tạo mới
                }

                // 3. Lưu danh sách mới
                await _repo.AddRangeAsync(newDetails);
                await _repo.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
