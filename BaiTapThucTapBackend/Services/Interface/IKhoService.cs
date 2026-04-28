using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IKhoService
    {
        Task<List<KhoDto>> GetAll();
        Task<KhoDto> Create(CreateKhoRequest request);
        Task<KhoDto> Update(int id,CreateKhoRequest request);

        Task Delete(int id);
    }
}
