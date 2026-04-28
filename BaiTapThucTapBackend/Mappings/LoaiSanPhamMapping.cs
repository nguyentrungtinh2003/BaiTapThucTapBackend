using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

    public static class LoaiSanPhamMapping
    {
        public static LoaiSanPhamDto ToDto(this LoaiSanPham entity)
        {
            return new LoaiSanPhamDto
            {
                Id = entity.Id,
                Ma_LSP = entity.Ma_LSP,
                Ten_LSP = entity.Ten_LSP,
                Ghi_Chu = entity.Ghi_Chu
            };
        }
    }

