using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface ISanPhamRepository
    {
        Task<List<SanPham>> GetAll();
        Task<SanPham> GetById(int id);
        Task Add(SanPham entity);
        Task Update(SanPham entity);
        Task Delete(SanPham entity);

        Task<bool> ExistsMa(string ma);
    }
}
