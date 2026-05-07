using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Repositories.Interface
{
	public interface INhapKhoDetailRepository
	{
		Task Update(NhapKhoDetail entity);
		Task Delete(NhapKhoDetail entity);
	}
}
