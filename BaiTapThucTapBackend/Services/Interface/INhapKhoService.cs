using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface INhapKhoService
    {
        Task<List<NhapKhoDto>> GetAll(int userKhoId, bool isAdmin);
        Task<NhapKhoDto> Create(CreateNhapKhoRequest request);

        Task<NhapKhoDto> GetById(int id);
        Task UpdateDetails(int id,NhapKhoDetailDto entity);
        Task Delete(int id);

        Task<List<BaoCaoNhapKhoDto>> BaoCaoChiTietHangNhap(DateTime startDate, DateTime endDate, int userKhoId, bool isAdmin);
    }
}
