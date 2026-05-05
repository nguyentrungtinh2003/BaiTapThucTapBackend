using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class XuatKhoService : IXuatKhoService
    {
        private readonly IXuatKhoRepository _repo;

        public XuatKhoService(IXuatKhoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<XuatKhoDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(XuatKhoMapping.ToDto).ToList();
        }

        public async Task<XuatKhoDto> Create(CreateXuatKhoRequest request)
        {
            if (string.IsNullOrEmpty(request.So_Phieu_Xuat_Kho))
            {
                throw new Exception("Số phiếu xuất kho không được rỗng");
            }
            if (request.Kho_ID <= 0)
            {
                throw new Exception("Kho không hợp lệ");
            }
            if (request.Ngay_Xuat_Kho == default)
            {
                throw new Exception("Ngày xuất kho không hiển thị");
            }

            var exists = await _repo.ExistsSoPhieu(request.So_Phieu_Xuat_Kho);
            if (exists)
            {
                throw new Exception("Số phiếu xuất kho đã tồn tại");
            }

            var entity = XuatKhoMapping.ToEntity(request);
            await _repo.Add(entity);
            return XuatKhoMapping.ToDto(entity);
        }

        public async Task Delete(int id)
        {
            var exists = await _repo.GetById(id);
            if (exists == null)
            {
                throw new Exception("Không tìm thấy");
            }
            await _repo.Delete(exists);
        }
    }
}
