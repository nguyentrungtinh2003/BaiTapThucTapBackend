using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface ILoaiSanPhamRepository
    {
        Task<List<LoaiSanPham>> GetAll();
        Task<LoaiSanPham> GetById(int id);

        Task Add(LoaiSanPham entity);
        Task Update(LoaiSanPham entity);

        Task Delete(LoaiSanPham entity);

        Task<bool> ExistsMa(string ma);
        Task<bool> ExistsTen(string ten);
    }
}
