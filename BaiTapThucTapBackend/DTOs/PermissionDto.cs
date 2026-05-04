namespace BaiTapThucTapBackend.DTOs
{
    public class PermissionDto
    {
        public string Ma_Dang_Nhap { get; set; }
        public int Kho_ID { get; set; }
        public bool isAdmin { get; set; } = false;
    }
}
