namespace BaiTapThucTapBackend.DTOs
{
    public class CreateLoaiSanPhamRequest
    {
        public int Id { get; set; }

        public string? Ma_LSP { get; set; }

        public string? Ten_LSP { get; set; }

        public string? Ghi_Chu { get; set; }
    }
}
