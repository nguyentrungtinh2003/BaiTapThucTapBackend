using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.Mappings
{
    public static class XNKNhapKhoMapping
    {
        public static XNKNhapKho ToEntity(CreateXNKNhapKhoRequest request)
        {
            return new XNKNhapKho
            {
                So_Phieu_Nhap_Kho = request.So_Phieu_Nhap_Kho,
                Kho_ID = request.Kho_ID,
                NCC_ID = request.NCC_ID,
                Ngay_Nhap_Kho = request.Ngay_Nhap_Kho,
                Ghi_Chu = request.Ghi_Chu,
                ChiTiets = request.ChiTiets.Select(d => new XNKNhapKhoDetail
                {
                    San_Pham_ID = d.San_Pham_ID,
                    SL_Nhap = d.SL_Nhap,
                    Don_Gia_Nhap = d.Don_Gia_Nhap
                }).ToList()
            };
        }

        public static XNKNhapKhoDto ToDto(XNKNhapKho entity)
        {
            return new XNKNhapKhoDto
            {
                Id = entity.Id,
                So_Phieu_Nhap_Kho = entity.So_Phieu_Nhap_Kho,
                Kho_ID = entity.Kho_ID,
                Ten_Kho = entity.Kho?.Ten_Kho,
                NCC_ID = entity.NCC_ID,
                Ten_NCC = entity.NhaCungCap?.Ten_NCC,
                Ngay_Nhap_Kho = entity.Ngay_Nhap_Kho,
                Ghi_Chu = entity.Ghi_Chu,
                ChiTiets = entity.ChiTiets?.Select(d => new XNKNhapKhoDetailDto
                {
                    San_Pham_ID = d.San_Pham_ID,
                    SL_Nhap = d.SL_Nhap,
                    Don_Gia_Nhap = d.Don_Gia_Nhap
                }).ToList()
            };
        }
    }
}
