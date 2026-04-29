using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.Models
{
    public class DonViTinh
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ten don vi tinh khong duoc rong")]
        public string? Ten_Don_Vi_Tinh { get; set; }

        public string? Ghi_Chu { get; set; }
    }
}
