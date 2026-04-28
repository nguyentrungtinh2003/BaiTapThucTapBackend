using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface INhaCungCapRepository
    {
        Task<List<NhaCungCap>> GetAll();
        Task<NhaCungCap> GetById(int id);
        Task Add(NhaCungCap entity);
        Task Update(NhaCungCap entity);
        Task Delete(NhaCungCap entity);
    }
}
