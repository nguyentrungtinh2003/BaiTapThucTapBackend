using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.Models
{
    public class Kho
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên kho không được rỗng")]
        public string? Ten_Kho { get; set; }
        public string? Ghi_Chu { get; set; }
    }
}
