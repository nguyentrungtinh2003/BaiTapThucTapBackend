using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface INhapKhoRepository
    {
        Task<List<NhapKho>> GetAll();
        Task<NhapKho> GetById(int id);
        Task<bool> ExistsSoPhieu(string sophieu);
        Task Add(NhapKho entity);
        Task Delete(NhapKho entity);
    }
}
