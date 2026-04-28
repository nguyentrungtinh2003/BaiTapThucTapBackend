using BaiTapThucTapBackend.DTOs;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface IDonViTinhService
    {
        Task<List<DonViTinhDto>> GetAll();
        Task<DonViTinhDto> Create(CreateDonViTinhRequest request);
        Task<DonViTinhDto> Update(int id, CreateDonViTinhRequest request);
        Task Delete(int id);
    }
}
