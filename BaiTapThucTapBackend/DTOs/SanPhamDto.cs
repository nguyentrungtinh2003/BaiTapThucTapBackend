namespace BaiTapThucTapBackend.DTOs
{
    public class SanPhamDto
    {
        public int Id { get; set; }
        public string Ma_San_Pham { get; set; }
        public string Ten_San_Pham { get; set; }
        public int Loai_San_Pham_ID { get; set; }
        public string Ten_LSP { get; set; }
        public int Don_Vi_Tinh_ID { get; set; }
        public string Ten_Don_Vi_Tinh { get; set; }

        public string? Ghi_Chu { get; set; }
    }
}
