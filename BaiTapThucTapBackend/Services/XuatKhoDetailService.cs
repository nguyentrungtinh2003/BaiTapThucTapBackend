using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class XuatKhoDetailService : IXuatKhoDetailService
    {
        private readonly IXuatKhoDetailRepository _repo;

        public XuatKhoDetailService(IXuatKhoDetailRepository repo)
        {
            _repo = repo;
        }
        public async Task Create(XuatKhoDetail entity)
        {
            if (entity.SL_Xuat <= 0)
            {
                throw new Exception("So luong xuat khong hop le");
            }
            if (entity.Don_Gia_Xuat <= 0)
            {
                throw new Exception("Don gia xuat khong hop le");
            }

            await _repo.Create(entity);
        }

        public async Task<XuatKhoDetail> GetById(int id)
        {
            var entity = await _repo.GetById(id);
            return entity;
        }
        public async Task Update(int id, XuatKhoDetail entity)
        {
            var item = await _repo.GetById(id);
            if (item == null)
            {
                throw new Exception("Khong tim thay");
            }

            item.SL_Xuat = entity.SL_Xuat;
            item.Don_Gia_Xuat = entity.Don_Gia_Xuat;

            await _repo.Update(item);
        }

        public async Task Delete(int id)
        {
            var item = await _repo.GetById(id);
            await _repo.Delete(item);
        }
    }

}
