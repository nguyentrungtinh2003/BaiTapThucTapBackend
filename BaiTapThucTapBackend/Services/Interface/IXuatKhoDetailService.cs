using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IXuatKhoDetailService { 


         Task Create(XuatKhoDetail entity);
    Task<XuatKhoDetail> GetById(int id);
    Task Update(int id, XuatKhoDetail entity);
    Task Delete(int id);
}
}
