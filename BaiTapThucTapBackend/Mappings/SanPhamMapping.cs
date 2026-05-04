using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

public static class SanPhamMapping
{
    public static SanPhamDto ToDto(this SanPham entity)
    {
        return new SanPhamDto
        {
            Id = entity.Id,
            Ma_San_Pham = entity.Ma_San_Pham,
            Ten_San_Pham = entity.Ten_San_Pham,
            Loai_San_Pham_ID = entity.Loai_San_Pham_ID,
            Ten_LSP = entity.LoaiSanPham?.Ten_LSP,
            Don_Vi_Tinh_ID = entity.Don_Vi_Tinh_ID,
            Ten_Don_Vi_Tinh = entity.DonViTinh?.Ten_Don_Vi_Tinh,
            Ghi_Chu = entity.Ghi_Chu
        };
    }
}