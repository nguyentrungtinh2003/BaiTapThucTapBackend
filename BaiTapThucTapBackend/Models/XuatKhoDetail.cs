using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucTapBackend.Models
{
    public class XuatKhoDetail
    {
        public int Id { get; set; }

        [ForeignKey("XuatKho")]

        public int Xuat_Kho_ID { get; set; }
        public XuatKho XuatKho { get; set; }

        [ForeignKey("SanPham")]

        public int San_Pham_ID { get; set; }
        public SanPham SanPham { get; set; }

        public int SL_Xuat { get; set; }
        public decimal Don_Gia_Xuat { get; set; }
    }
}
