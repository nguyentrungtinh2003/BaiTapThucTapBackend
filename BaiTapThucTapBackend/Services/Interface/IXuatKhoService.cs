using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IXuatKhoService
    {
        Task<List<XuatKhoDto>> GetAll();
        Task<XuatKhoDto> Create(CreateXuatKhoRequest request);
        Task Delete(int id);
    }
}
