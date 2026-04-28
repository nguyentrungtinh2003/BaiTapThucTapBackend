using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IDonViTinhRepository
    {
        Task<List<DonViTinh>> GetAll();
        Task<DonViTinh> GetById(int id);

        Task Add(DonViTinh entity);
        Task Update(DonViTinh entity);

        Task Delete(DonViTinh entity);

        Task<bool> Exists(string ten);
    }
}
