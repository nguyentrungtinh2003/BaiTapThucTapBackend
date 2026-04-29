using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucTapBackend.Models
{
    public class NhapKhoDetail
    {
        public int Id { get; set; }
        public int Nhap_Kho_ID { get; set; }
        public int San_Pham_ID { get; set; }

        public int SL_Nhap { get; set; }

        public decimal Don_Gia_Nhap { get; set; }

        [ForeignKey("Nhap_Kho_ID")]
        public NhapKho? NhapKho { get; set; }
        [ForeignKey("San_Pham_ID")]
        public SanPham? SanPham { get; set; }
    }
}
