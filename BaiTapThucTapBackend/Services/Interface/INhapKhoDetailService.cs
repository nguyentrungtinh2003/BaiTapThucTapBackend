using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Services.Interface
{
    public interface INhapKhoDetailService
    {
        Task Create(NhapKhoDetail entity);
        Task<NhapKhoDetail> GetById(int id);
        Task Update(int id, NhapKhoDetail entity);
        Task Delete(int id);
    }
}
