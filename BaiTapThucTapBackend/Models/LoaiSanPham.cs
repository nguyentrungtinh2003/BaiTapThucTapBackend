using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.Models
{
    public class LoaiSanPham
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã loại sản phẩm không được rỗng")]
        public string? Ma_LSP { get; set; }
        [Required(ErrorMessage = "Tên loại sản phẩm không được rỗng")]
        public string? Ten_LSP { get; set; }

        public string? Ghi_Chu { get; set; }

        public ICollection<SanPham> SanPhams { get; set; }
    }
}
