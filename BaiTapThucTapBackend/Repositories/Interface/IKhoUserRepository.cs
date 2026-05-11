using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IKhoUserRepository
    {
        Task<List<KhoUser>> GetAll();
        Task<KhoUser> Get(string Ma_Dang_Nhap, int Kho_ID);
        Task Add(KhoUser entity);
        Task Delete(KhoUser entity);

        Task<bool> Exists(string Ma_Dang_Nhap, int KhoID);

        //---

        Task<List<KhoUser>> GetByUser(string Ma_Dang_Nhap);

        Task<KhoUser?> GetByKey(string Ma_Dang_Nhap, int Kho_ID);

    }
}
