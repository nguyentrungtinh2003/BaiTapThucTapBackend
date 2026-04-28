namespace BaiTapThucTapBackend.Models
{
    public class NhapKhoDetail
    {
        public int Id { get; set; }
        public int Nhap_Kho_ID { get; set; }
        public int San_Pham_ID { get; set; }

        public int SL_Nhap { get; set; }

        public decimal Don_Gia_Nhap { get; set; }

        public NhapKho NhapKho { get; set; }
        public SanPham SanPham { get; set; }
    }
}
