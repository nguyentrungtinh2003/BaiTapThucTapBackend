using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
	public interface INhapKhoDetailRepository
	{
		Task Create(NhapKhoDetail entity);
		Task<NhapKhoDetail> GetById(int id);
		Task Update(NhapKhoDetail entity);
		Task Delete(NhapKhoDetail entity);
	}
}
