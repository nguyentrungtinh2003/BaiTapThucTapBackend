using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.DTOs
{
    public class XuatKhoDetailDto
    {
        public int Id { get; set; }

        public int Xuat_Kho_ID { get; set; }
        public int San_Pham_ID { get; set; }

        public string? Ma_San_Pham { get; set; }
        public string? Ten_San_Pham { get; set; }
        public string? Ten_Don_Vi_Tinh { get; set; }
        public int SL_Xuat { get; set; }
        public decimal Don_Gia_Xuat { get; set; }
    }
}
