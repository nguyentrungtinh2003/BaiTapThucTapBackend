using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IXuatKhoService
    {
        Task<List<XuatKhoDto>> GetAll();
        Task<XuatKhoDto> Create(CreateXuatKhoRequest request);

        Task<XuatKhoDto> GetById(int id);
        Task UpdateDetails(int id, XuatKhoDetailDto entity);
        Task Delete(int id);
    }
}
