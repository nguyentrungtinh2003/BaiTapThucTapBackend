using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface INhaCungCapService
    {
        Task<List<NhaCungCapDto>> GetAll();
        Task<NhaCungCapDto> Create(CreateNhaCungCapRequest request);
        Task<NhaCungCapDto> Update(int id, CreateNhaCungCapRequest request);
        Task Delete(int id);
    }
}
