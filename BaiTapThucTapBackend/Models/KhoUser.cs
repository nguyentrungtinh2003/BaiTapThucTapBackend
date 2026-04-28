using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.Models
{
    public class KhoUser
    {
        [Required]
        public int User_ID { get; set; }
        [Required]
        public int Kho_ID { get; set; }

        public User User { get; set; }
        public Kho Kho { get; set; }

    }
}
