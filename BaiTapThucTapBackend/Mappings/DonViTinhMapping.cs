using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

public static class DonViTinhMapping
{
    public static DonViTinhDto ToDto(this DonViTinh entity)
    {
        return new DonViTinhDto
        {
            Id = entity.Id,
            Ten_Don_Vi_Tinh = entity.Ten_Don_Vi_Tinh,
            Ghi_Chu = entity.Ghi_Chu
        };
    }
}