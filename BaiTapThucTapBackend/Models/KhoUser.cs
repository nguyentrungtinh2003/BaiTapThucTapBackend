using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucTapBackend.Models
{
    public class KhoUser
    {
        [Required]
        public int User_ID { get; set; }
        [Required]
        public int Kho_ID { get; set; }

        [ForeignKey("User_ID")]
        public User? User { get; set; }
        [ForeignKey("Kho_ID")]
        public Kho? Kho { get; set; }

    }
}
