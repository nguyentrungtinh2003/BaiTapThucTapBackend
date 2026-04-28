using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

public static class NhapKhoMapping
{
    public static NhapKho ToEntity(CreateNhapKhoRequest request)
    {
        return new NhapKho
        {
            So_Phieu_Nhap_Kho = request.So_Phieu_Nhap_Kho,
            Kho_ID = request.Kho_ID,
            NCC_ID = request.NCC_ID,
            Ngay_Nhap_Kho = request.Ngay_Nhap_Kho,
            Ghi_Chu = request.Ghi_Chu,
            Details = request.Details.Select(d => new NhapKhoDetail
            {
                San_Pham_ID = d.San_Pham_ID,
                SL_Nhap = d.SL_Nhap,
                Don_Gia_Nhap = d.Don_Gia_Nhap
            }).ToList()
        };
    }

    public static NhapKhoDto ToDto(NhapKho entity)
    {
        return new NhapKhoDto
        {
            Id = entity.Id,
            So_Phieu_Nhap_Kho = entity.So_Phieu_Nhap_Kho,
            Kho_ID = entity.Kho_ID,
            NCC_ID = entity.NCC_ID,
            Ngay_Nhap_Kho = entity.Ngay_Nhap_Kho,
            Ghi_Chu = entity.Ghi_Chu,
            Details = entity.Details.Select(d => new NhapKhoDetailDto
            {
                San_Pham_ID = d.San_Pham_ID,
                SL_Nhap = d.SL_Nhap,
                Don_Gia_Nhap = d.Don_Gia_Nhap
            }).ToList()
        };
    }
}