using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.DTOs
{
    public class CreateXNKXuatKhoRequest
    {
        public int Id { get; set; }
        public string So_Phieu_Xuat_Kho { get; set; }
        public int Kho_ID { get; set; }
        public string? Ten_Kho { get; set; }
        public DateTime Ngay_Xuat_Kho { get; set; }
        public string? Ghi_Chu { get; set; }
        public List<XNKNhapKhoDetail> ChiTiets { get; set; }
    }
}
