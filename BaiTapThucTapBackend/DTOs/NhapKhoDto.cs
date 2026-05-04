using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.DTOs
{
    public class NhapKhoDto
    {
        public int Id { get; set; }
        public string? So_Phieu_Nhap_Kho { get; set; }

        public int Kho_ID { get; set; }

        public string Ten_Kho { get; set; }
        public int NCC_ID { get; set; }
        public string Ten_NCC { get; set; }

        public DateTime Ngay_Nhap_Kho { get; set; }

        public string? Ghi_Chu { get; set; }

        public List<NhapKhoDetailDto>? ChiTiets { get; set; }
    }
}
