using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IKhoRepository { 
        Task<List<Kho>> GetAll();
        Task<Kho> GetById(int id);
        Task Add(Kho entity);
        Task Update(Kho entity);
        Task Delete(Kho entity);

        Task<bool> ExistsTen(string ten);

    }
}
