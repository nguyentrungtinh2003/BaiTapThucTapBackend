using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucTapBackend.Models
{
    public class KhoUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã đãng nhập không được rỗng")]
        public string Ma_Dang_Nhap { get; set; }

        [ForeignKey("Kho")]
        public int Kho_ID { get; set; }
        public Kho Kho { get; set; }

    }
}
