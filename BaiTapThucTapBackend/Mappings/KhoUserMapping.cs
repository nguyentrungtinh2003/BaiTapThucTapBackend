using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

public static class KhoUserMapping
{
    public static KhoUserDto ToDto(this KhoUser entity)
    {
        return new KhoUserDto
        {
            User_ID = entity.User_ID,
            Kho_ID = entity.Kho_ID
        };
    }

    public static KhoUser ToEntity(CreateKhoUserRequest request)
    {
        return new KhoUser
        {
            User_ID = request.User_ID,
            Kho_ID = request.Kho_ID
        };
    }
}