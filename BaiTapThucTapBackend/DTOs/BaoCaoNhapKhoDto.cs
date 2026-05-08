namespace BaiTapThucTapBackend.DTOs
{
    public class BaoCaoNhapKhoDto
    {
        public DateTime Ngay_Nhap { get; set; }
        public string? So_Phieu_Nhap_Kho { get; set; }
        public string? Ten_NCC { get; set; }
        public string? Ma_San_Pham { get; set; }
        public string? Ten_San_Pham { get; set; }
        public int SL_Nhap { get; set; }
        public decimal Don_Gia_Nhap { get; set; }
    }
}
