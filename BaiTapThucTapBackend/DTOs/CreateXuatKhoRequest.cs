using BaiTapThucTapBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.DTOs
{
    public class CreateXuatKhoRequest { 
    public string So_Phieu_Xuat_Kho { get; set; }
    public int Kho_ID { get; set; }
    public DateTime Ngay_Xuat_Kho { get; set; }
    public string? Ghi_Chu { get; set; }
    public List<XuatKhoDetail> ChiTiets { get; set; }
}
}
