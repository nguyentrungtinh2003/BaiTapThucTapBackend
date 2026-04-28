using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IKhoUserRepository
    {
        Task<List<KhoUser>> GetAll();
        Task<KhoUser> Get(int User_ID, int Kho_ID);
        Task Add(KhoUser entity);
        Task Delete(KhoUser entity);

        Task<bool> Exists(int UserID, int KhoID);
    }
}
