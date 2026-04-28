using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface INhapKhoService
    {
        Task<List<NhapKhoDto>> GetAll();
        Task<NhapKhoDto> Create(CreateNhapKhoRequest request);
        Task Delete(int id);
    }
}
