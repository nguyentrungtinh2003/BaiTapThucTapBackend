using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IXNKXuatKhoRepository
    {
        Task<List<XNKXuatKho>> GetAll();

        Task<bool> ExistsSoPhieu(string sophieu);

        Task<XNKXuatKho?> GetBySoPhieuAsync(string soPhieu);
        Task Add(XNKXuatKho entity);
        Task Update(XNKXuatKho entity);

        Task SaveChangesAsync();
    }
}
