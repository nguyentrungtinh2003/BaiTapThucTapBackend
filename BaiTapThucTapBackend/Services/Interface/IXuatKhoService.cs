using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IXuatKhoService
    {
        Task<List<XuatKhoDto>> GetAll(int userKhoId, bool isAdmin);
        Task<XuatKhoDto> Create(CreateXuatKhoRequest request);

        Task<XuatKhoDto> GetById(int id);
        Task UpdateDetails(int id, XuatKhoDetailDto entity);
        Task Delete(int id);
        Task<List<BaoCaoXuatKhoDto>> BaoCaoChiTietHangXuat(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin);
    }
}
