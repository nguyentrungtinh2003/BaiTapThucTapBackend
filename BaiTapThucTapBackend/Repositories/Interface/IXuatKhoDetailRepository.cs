using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IXuatKhoDetailRepository
    {
        Task Create(XuatKhoDetail entity);
        Task<XuatKhoDetail> GetById(int id);
        Task Update(XuatKhoDetail entity);
        Task Delete(XuatKhoDetail entity);
    }
}
