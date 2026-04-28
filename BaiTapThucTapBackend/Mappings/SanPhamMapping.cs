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
            Don_Vi_Tinh_ID = entity.Don_Vi_Tinh_ID,
            Ghi_Chu = entity.Ghi_Chu
        };
    }
}