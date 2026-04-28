using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface ISanPhamService
    {
        Task<List<SanPhamDto>> GetAll();
        Task<SanPhamDto> Create(CreateSanPhamRequest request);
        Task<SanPhamDto> Update(int id, CreateSanPhamRequest request);

        Task Delete(int id);
    }
}
