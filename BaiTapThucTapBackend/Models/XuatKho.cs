using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucTapBackend.Models
{
    public class XuatKho { 
        public int Id { get; set; }
        [Required(ErrorMessage = "Số phiếu xuất kho không được rỗng")]
        public string So_Phieu_Xuat_Kho { get; set; }
        [ForeignKey("Kho")]

        public int Kho_ID { get; set; }
        public Kho Kho { get; set; }
        public DateTime Ngay_Xuat_Kho { get; set; }
        public string? Ghi_Chu { get; set; }
        public List<XuatKhoDetail> ChiTiets { get; set; }
    }
}
