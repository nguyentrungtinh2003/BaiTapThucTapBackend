using BaiTapThucTapBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IXNKNhapKhoRepository
    {
        Task<List<XNKNhapKho>> GetAll();

        Task<bool> ExistsSoPhieu(string sophieu);

        Task<XNKNhapKho?> GetBySoPhieuAsync(string soPhieu);
        Task Add(XNKNhapKho entity);
        Task Update(XNKNhapKho entity);

        Task SaveChangesAsync();
    }
}
