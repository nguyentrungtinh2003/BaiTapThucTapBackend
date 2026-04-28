using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface ILoaiSanPhamService
    {
        Task<List<LoaiSanPhamDto>> GetAll();

        Task<LoaiSanPhamDto> Create(CreateLoaiSanPhamRequest request);
        Task<LoaiSanPhamDto> Update(int id,CreateLoaiSanPhamRequest request);
        Task Delete(int id);
    }
}
