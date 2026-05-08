using BaiTapThucTapBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucTapBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XuatNhapTonController : ControllerBase
    {
        private readonly IXuatNhapTonService _service;
        public XuatNhapTonController(IXuatNhapTonService service)
        {
            _service = service;
        }

        [HttpGet("bao-cao-xuat-nhap-ton")]
        public async Task<IActionResult> BaoCaoXuatNhapTon([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int userKhoId, [FromQuery] bool isAdmin)
        {
            return Ok(await _service.BaoCaoXuatNhapTon(startDate, endDate, userKhoId, isAdmin));
        }
    }
}
