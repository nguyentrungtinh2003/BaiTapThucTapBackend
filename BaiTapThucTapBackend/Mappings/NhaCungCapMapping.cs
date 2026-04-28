using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

public static class NhaCungCapMapping
{
    public static NhaCungCapDto ToDto(this NhaCungCap entity)
    {
        return new NhaCungCapDto
        {
            Id = entity.Id,
            Ma_NCC = entity.Ma_NCC,
            Ten_NCC = entity.Ten_NCC,
            Ghi_Chu = entity.Ghi_Chu
        };
    }
}