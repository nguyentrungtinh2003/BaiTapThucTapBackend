using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface INhapKhoService
    {
        Task<List<NhapKhoDto>> GetAll();
        Task<NhapKhoDto> Create(CreateNhapKhoRequest request);

        Task<NhapKhoDto> GetById(int id);
        Task UpdateDetails(int id,NhapKhoDetailDto entity);
        Task Delete(int id);
    }
}
