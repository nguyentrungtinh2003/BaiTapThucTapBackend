using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

public static class KhoMapping
{
    public static KhoDto ToDto(this Kho entity)
    {
        return new KhoDto
        {
           Id = entity.Id,
           Ten_Kho = entity.Ten_Kho,
           Ghi_Chu = entity.Ghi_Chu
        };
    }
}