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
                throw new Exception("So phieu nhap kho khong duoc rong");
            }
            if (request.Kho_ID <= 0)
            {
                throw new Exception("Kho khong hop le");
            }
            if (request.Ngay_Xuat_Kho == default)
            {
                throw new Exception("Ngay xuat kho khong hien thi");
            }

            var exists = await _repo.ExistsSoPhieu(request.So_Phieu_Xuat_Kho);
            if (exists)
            {
                throw new Exception("So phieu xuat kho da ton tai");
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
                throw new Exception("Khong tim thay");
            }
            await _repo.Delete(exists);
        }
    }
}
