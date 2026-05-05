using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface INhapKhoService
    {
        Task<List<NhapKhoDto>> GetAll();
        Task<NhapKhoDto> Create(CreateNhapKhoRequest request);

        Task<NhapKhoDto> Update(NhapKho entity);
        Task Delete(int id);
    }
}
