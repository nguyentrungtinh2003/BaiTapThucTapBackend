using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucTapBackend.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã sản phẩm không được rỗng")]
        public string? Ma_San_Pham { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được rỗng")]
        public string? Ten_San_Pham { get; set; }

        [ForeignKey("LoaiSanPham")]

        public int Loai_San_Pham_ID { get; set; }
        public LoaiSanPham? LoaiSanPham { get; set; }
        [ForeignKey("DonViTinh")]

        public int Don_Vi_Tinh_ID { get; set; }
        public DonViTinh? DonViTinh { get; set; }


        public string? Ghi_Chu { get; set; }
    }
}
