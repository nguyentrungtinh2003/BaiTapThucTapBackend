using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucTapBackend.Models
{
    public class NhapKho
    {
        [Key]
        public int Id { get; set; }
        public string? So_Phieu_Nhap_Kho { get; set; }

        public int Kho_ID { get; set; }
        public int NCC_ID { get; set; }

        public DateTime Ngay_Nhap_Kho { get; set; }

        public string? Ghi_Chu { get; set; }

        // --
        [ForeignKey("Kho_ID")]
        public Kho? Kho { get; set; }
        [ForeignKey("NhaCungCap_ID")]
        public NhaCungCap? NhaCungCap { get; set;}

        public List<NhapKhoDetail>? Details { get; set; }
    }
}
