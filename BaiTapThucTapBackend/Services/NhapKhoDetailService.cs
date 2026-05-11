using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class NhapKhoDetailService : INhapKhoDetailService
    {
        private readonly INhapKhoDetailRepository _repo;

        public NhapKhoDetailService(INhapKhoDetailRepository repo)
        {
            _repo = repo;
        }
        public async Task Create(NhapKhoDetail entity)
        {
            if(entity.Nhap_Kho_ID <= 0)
            {
                throw new Exception("Nhập kho không được rỗng");
            }
            if(entity.San_Pham_ID <= 0)
            {
                throw new Exception("Sản phẩm không được rỗng");
            }
            if(entity.SL_Nhap <= 0)
            {
                throw new Exception("Số lượng nhập kho không hợp lệ");
            }
            if(entity.Don_Gia_Nhap <= 0)
            {
                throw new Exception("Đơn giá nhập không hợp lệ");
            }

            await _repo.Create(entity);
        }

        public async Task<NhapKhoDetail> GetById(int id)
        {
            var entity = await _repo.GetById(id);
            return entity;
        }
        public async Task Update(int id, NhapKhoDetail entity)
        {
            var item = await _repo.GetById(id);
            if(item == null)
            {
                throw new Exception("Không tìm thấy");
            }

            item.SL_Nhap = entity.SL_Nhap;
            item.Don_Gia_Nhap = entity.Don_Gia_Nhap;

            await _repo.Update(item);
        }

        public async Task Delete(int id)
        {
            var item = await _repo.GetById(id);
            await _repo.Delete(item);
        }
    }
}
