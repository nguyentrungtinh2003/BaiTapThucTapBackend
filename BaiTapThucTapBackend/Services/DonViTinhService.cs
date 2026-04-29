using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class DonViTinhService : IDonViTinhService
    {
        public readonly IDonViTinhRepository _repo;
        public DonViTinhService(IDonViTinhRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<DonViTinhDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(x => x.ToDto()).ToList();
        }

        public async Task<DonViTinhDto> Create(CreateDonViTinhRequest request)
        {
            if(string.IsNullOrEmpty(request.Ten_Don_Vi_Tinh))
            {
                throw new Exception("Tên đơn vị tính không được rỗng");
            }

            if(await _repo.Exists(request.Ten_Don_Vi_Tinh))
            {
                throw new Exception("Tên dơn vị tính đã tồn tại");
            }

            var entity = new DonViTinh
            {
                Ten_Don_Vi_Tinh = request.Ten_Don_Vi_Tinh,
                Ghi_Chu = request.Ghi_Chu
            };

            await _repo.Add(entity);
            return entity.ToDto();
        }

        public async Task<DonViTinhDto> Update(int id, CreateDonViTinhRequest request)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Không tịm thấy đơn vị tính");
            }
            entity.Ten_Don_Vi_Tinh = request.Ten_Don_Vi_Tinh;
            entity.Ghi_Chu = request.Ghi_Chu;

            await _repo.Update(entity);
            return entity.ToDto();
        }

        public async Task Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Không tìm thấy đơn vị tính");
            }

            await _repo.Delete(entity);
        }
    }
}
