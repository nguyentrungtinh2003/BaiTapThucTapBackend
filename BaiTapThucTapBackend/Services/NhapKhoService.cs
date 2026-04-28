using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class NhapKhoService : INhapKhoService
    {
        private readonly INhapKhoRepository _repo;

        public NhapKhoService(INhapKhoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<NhapKhoDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(NhapKhoMapping.ToDto).ToList();
        }

        public async Task<NhapKhoDto> Create(CreateNhapKhoRequest request)
        {
            if (string.IsNullOrEmpty(request.So_Phieu_Nhap_Kho))
            {
                throw new Exception("So phieu nhap kho khong duoc rong");
            }
            if (request.Kho_ID <= 0)
            {
                throw new Exception("Kho khong hop le");
            }
            if (request.NCC_ID <= 0)
            {
                throw new Exception("Nha cung cap khong hop le");
            }
            if (request.Ngay_Nhap_Kho == default)
            {
                throw new Exception("Ngay nhap kho khong hien thi");
            }

            var exists = await _repo.ExistsSoPhieu(request.So_Phieu_Nhap_Kho);
            if(exists)
            {
                throw new Exception("So phieu nhap kho da ton tai");
            }

            var entity = NhapKhoMapping.ToEntity(request);
            await _repo.Add(entity);
            return NhapKhoMapping.ToDto(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _repo.GetById(id);

            if(entity == null)
            {
                throw new Exception("Khong tim thay");
            }
            await _repo.Delete(entity);
        }
    }
}
