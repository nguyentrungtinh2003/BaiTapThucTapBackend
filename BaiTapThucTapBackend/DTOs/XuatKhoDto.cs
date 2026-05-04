using BaiTapThucTapBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace BaiTapThucTapBackend.DTOs
{
    public class XuatKhoDto
    { 
    public int Id { get; set; }
    public string So_Phieu_Xuat_Kho { get; set; }
    public int Kho_ID { get; set; }
    public Kho Kho { get; set; }
    public DateTime Ngay_Xuat_Kho { get; set; }
    public string? Ghi_Chu { get; set; }
    public List<XuatKhoDetailDto> ChiTiets { get; set; }
}
}
