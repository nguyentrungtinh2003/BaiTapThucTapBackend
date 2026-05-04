using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IXNKNhapKhoDetailRepository
    {
        Task<List<XNKNhapKhoDetail>> GetByHeaderIdAsync(int maNhapKho);
        Task ClearDetailsByHeaderIdAsync(int maNhapKho); // Xóa chi tiết cũ để ghi đè mới
        Task AddRangeAsync(List<XNKNhapKhoDetail> details);
        Task SaveChangesAsync();
    }
}
