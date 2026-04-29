using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.DTOs
{
    public class CreateNhapKhoRequest
    {
        public string? So_Phieu_Nhap_Kho { get; set; }

        public int Kho_ID { get; set; }
        public int NCC_ID { get; set; }

        public DateTime Ngay_Nhap_Kho { get; set; }

        public string? Ghi_Chu { get; set; }

        public List<NhapKhoDetail>? Details { get; set; } = new();
    }
}
