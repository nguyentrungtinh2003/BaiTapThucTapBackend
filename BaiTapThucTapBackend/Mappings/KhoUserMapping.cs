using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

public static class KhoUserMapping
{
    public static KhoUserDto ToDto(this KhoUser entity)
    {
        return new KhoUserDto
        {
            Ma_Dang_Nhap = entity.Ma_Dang_Nhap,
            Kho_ID = entity.Kho_ID
        };
    }

    public static KhoUser ToEntity(CreateKhoUserRequest request)
    {
        return new KhoUser
        {
            Ma_Dang_Nhap = request.Ma_Dang_Nhap,
            Kho_ID = request.Kho_ID
        };
    }
}