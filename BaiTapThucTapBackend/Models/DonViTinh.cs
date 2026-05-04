using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.Models
{
    public class DonViTinh
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đơn vị tính không được rỗng")]
        public string? Ten_Don_Vi_Tinh { get; set; }

        public string? Ghi_Chu { get; set; }

        private ICollection<SanPham> SanPhams { get;  set; }
    }
}
