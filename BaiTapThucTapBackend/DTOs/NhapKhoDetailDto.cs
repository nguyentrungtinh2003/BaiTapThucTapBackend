using BaiTapThucTapBackend.Models;

namespace BaiTapThucTapBackend.DTOs
{
    public class NhapKhoDetailDto
    {
        public int Id { get; set; }
        public int Nhap_Kho_ID { get; set; }
        public int San_Pham_ID { get; set; }

        public string Ma_San_Pham { get; set; }
        public string Ten_San_Pham { get; set; }
        public string Ten_Don_Vi_Tinh { get; set; }

        public int SL_Nhap { get; set; }

        public decimal Don_Gia_Nhap { get; set; }

    }
}
