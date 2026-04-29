namespace BaiTapThucTapBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Ma_Dang_Nhap { get; set; }
        public string? Mat_Khau { get; set; }
        public string? Role { get; set; }

        public List<KhoUser>? KhoUsers { get; set; }
    }
}
