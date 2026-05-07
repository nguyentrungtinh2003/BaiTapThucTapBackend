using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.Models
{
    public class XNKNhapKho
    {
        public int Id { get; set; }

        [ForeignKey("NhapKho")]
        public int Nhap_Kho_ID { get; set; }
        public NhapKho? NhapKho { get; set; }

        [Required(ErrorMessage = "Số phiếu nhập kho không được rỗng")]
        public string So_Phieu_Nhap_Kho { get; set; }

        [ForeignKey("Kho")]

        public int Kho_ID { get; set; }
        public Kho? Kho { get; set; }

        [ForeignKey("NhaCungCap")]

        public int NCC_ID { get; set; }
        public NhaCungCap? NhaCungCap { get; set; }

        public DateTime Ngay_Nhap_Kho { get; set; }

        public string? Ghi_Chu { get; set; }
        public bool IsLatest { get; set; }
        public DateTime Updated_At { get; set; }
        public int Version { get; set; }
        public ICollection<XNKNhapKhoDetail> ChiTiets { get; set; }
    }
}
