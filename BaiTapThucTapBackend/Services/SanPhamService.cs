using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Services
{
    public class SanPhamService : ISanPhamService
    {
        private readonly ISanPhamRepository _repo;
        private readonly AppDbcontext _context;

        public SanPhamService(ISanPhamRepository repo, AppDbcontext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<List<SanPhamDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(x => x.ToDto()).ToList();
        }

        public async Task<SanPhamDto> Create(CreateSanPhamRequest request)
        {
            if (string.IsNullOrEmpty(request.Ma_San_Pham))
            {
                throw new Exception("Ma san pham khong duoc rong");
            }
            if (string.IsNullOrEmpty(request.Ten_San_Pham))
            {
                throw new Exception("Ten san pham khong duoc rong");
            }
            if(request.Loai_San_Pham_ID <= 0)
            {
                throw new Exception("Phai chon loai san pham");
            }
            if(request.Don_Vi_Tinh_ID <= 0)
            {
                throw new Exception("Phai chon don vi tinh");
            }
            if(await _repo.ExistsMa(request.Ma_San_Pham))
            {
                throw new Exception("Ma da ton tai");
            }

            var lspExists = await _context.LoaiSanPhams.AnyAsync(x => x.Id == request.Loai_San_Pham_ID);
            var dvtExists = await _context.DonViTinhs.AnyAsync(x => x.Id == request.Don_Vi_Tinh_ID);

            if (!lspExists) throw new Exception("Loai san pham khong ton tai");
            if (!dvtExists) throw new Exception("Don vi tinh khong ton tai");

            var entity = new SanPham
            {
                Ma_San_Pham = request.Ma_San_Pham,
                Ten_San_Pham = request.Ten_San_Pham,
                Loai_San_Pham_ID = request.Loai_San_Pham_ID,
                Don_Vi_Tinh_ID = request.Don_Vi_Tinh_ID,
                Ghi_Chu = request.Ghi_Chu
            };

            await _repo.Add(entity);
            return entity.ToDto();
        }

        public async Task<SanPhamDto> Update(int id, CreateSanPhamRequest request)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Khong tim thay san pham");
            }

            entity.Ma_San_Pham = request.Ma_San_Pham;
            entity.Ten_San_Pham = request.Ten_San_Pham;
            entity.Loai_San_Pham_ID = request.Loai_San_Pham_ID;
            entity.Don_Vi_Tinh_ID = request.Don_Vi_Tinh_ID;
            entity.Ghi_Chu = request.Ghi_Chu;

            await _repo.Update(entity);
            return entity.ToDto();
        }

        public async Task Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Khong tim thay san pham");
            }
            await _repo.Delete(entity);
        }
    }
}
