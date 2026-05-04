using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucTapBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XNKNhapKhoController : ControllerBase
    {
        private readonly XNKNhapKhoService _service;

        public XNKNhapKhoController(XNKNhapKhoService service)
        {
            _service = service;
        }

        [HttpPost("adjustment")]
        public async Task<IActionResult> HandleAdjustment([FromBody] XNKNhapKho model)
        {
            if (model == null) return BadRequest("Dữ liệu không hợp lệ");

            var result = await _service.HandleAdjustmentAsync(model);

            if (result)
            {
                return Ok(new { message = "Hiệu chỉnh và lưu vào XNK thành công!" });
            }

            return BadRequest("Lỗi khi thực hiện hiệu chỉnh phiếu nhập");
        }
    }
}
