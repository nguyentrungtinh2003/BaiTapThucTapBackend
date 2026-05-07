using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.Models
{
    public class XNKXuatKho
    {
        public int Id { get; set; }

        [ForeignKey("XuatKho")]
        public int Xuat_Kho_ID { get; set; }
        public XuatKho? XuatKho { get; set; }
        [Required(ErrorMessage = "Số phiếu xuất kho không được rỗng")]
        public string So_Phieu_Xuat_Kho { get; set; }
        [ForeignKey("Kho")]

        public int Kho_ID { get; set; }
        public Kho? Kho { get; set; }
        public DateTime Ngay_Xuat_Kho { get; set; }
        public string? Ghi_Chu { get; set; }

        public bool IsLatest { get; set; }
        public DateTime Updated_At { get; set; }
        public int Version { get; set; }
        public List<XuatKhoDetail> ChiTiets { get; set; }
    }
}
