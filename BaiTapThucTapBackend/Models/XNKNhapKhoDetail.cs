using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucTapBackend.Models
{
    public class XNKNhapKhoDetail
    {
        public int Id { get; set; }
        [ForeignKey("XNKNhapKho")]

        public int XNKNhap_Kho_ID { get; set; }
        public XNKNhapKho? XNKNhapKho { get; set; }

        [ForeignKey("SanPham")]

        public int San_Pham_ID { get; set; }
        public SanPham? SanPham { get; set; }

        public int SL_Nhap { get; set; }
        public decimal Don_Gia_Nhap { get; set; }
    }
}
