using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
    public interface IXuatKhoRepository
    {
        Task<List<XuatKho>> GetAll();
        Task<XuatKho> GetById(int id);
        Task<bool> ExistsSoPhieu(string sophieu);
        Task Add(XuatKho entity);
        Task Delete(XuatKho entity);
        Task<List<BaoCaoXuatKhoDto>> BaoCaoChiTietHangXuat(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin);
    }
}
