using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.Models
{
    public class NhaCungCap
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã nhà cung cấp không được rỗng")]
        public string Ma_NCC { get; set; }
        [Required(ErrorMessage = "Tên nhà cung cấp không được rỗng")]
        public string Ten_NCC { get; set; }
        public string? Ghi_Chu { get; set; }
    }
}
