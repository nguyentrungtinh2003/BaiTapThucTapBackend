using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        [Required]
        public string Ma_San_Pham { get; set; }
        [Required]
        public string Ten_San_Pham { get; set; }

        [Required]
        public int Loai_San_Pham_ID { get; set; }
        [Required]
        public int Don_Vi_Tinh_ID { get; set; }

        public string? Ghi_Chu { get; set; }

        // ---

        public LoaiSanPham LoaiSanPham { get; set; }
        public DonViTinh DonViTinh { get; set; }

    }
}
