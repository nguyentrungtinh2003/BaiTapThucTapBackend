using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

public static class XuatKhoMapping
{
    public static XuatKho ToEntity(CreateXuatKhoRequest request)
    {
        return new XuatKho
        {
            So_Phieu_Xuat_Kho = request.So_Phieu_Xuat_Kho,
            Kho_ID = request.Kho_ID,
            Ngay_Xuat_Kho = request.Ngay_Xuat_Kho,
            Ghi_Chu = request.Ghi_Chu,
            ChiTiets = request.ChiTiets.Select(d => new XuatKhoDetail
            {
                Xuat_Kho_ID = d.Xuat_Kho_ID,
                San_Pham_ID = d.San_Pham_ID,
                SL_Xuat = d.SL_Xuat,
                Don_Gia_Xuat = d.Don_Gia_Xuat
            }).ToList()
        };
    }

    public static XuatKhoDto ToDto(XuatKho entity)
    {
        return new XuatKhoDto
        {
            Id = entity.Id,
            So_Phieu_Xuat_Kho = entity.So_Phieu_Xuat_Kho,
            Kho_ID = entity.Kho_ID,
            Ten_Kho = entity.Kho?.Ten_Kho,
            Ngay_Xuat_Kho = entity.Ngay_Xuat_Kho,
            Ghi_Chu = entity.Ghi_Chu,
            ChiTiets = entity.ChiTiets.Select(d => new XuatKhoDetailDto
            {
                Xuat_Kho_ID = d.Xuat_Kho_ID,
                San_Pham_ID = d.San_Pham_ID,
                SL_Xuat = d.SL_Xuat,
                Don_Gia_Xuat = d.Don_Gia_Xuat

            }).ToList()
        };
    }
}