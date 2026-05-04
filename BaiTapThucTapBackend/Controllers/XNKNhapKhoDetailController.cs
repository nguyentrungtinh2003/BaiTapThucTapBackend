using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucTapBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XNKNhapKhoDetailController : ControllerBase
    {
        private readonly IXNKNhapKhoDetailService _service;

        public XNKNhapKhoDetailController(IXNKNhapKhoDetailService service)
        {
            _service = service;
        }

        [HttpPost("adjustment/{headerId}")]
        public async Task<IActionResult> SyncDetails(int headerId, [FromBody] List<XNKNhapKhoDetail> details)
        {
            if (details == null || details.Count == 0)
                return BadRequest("Danh sách sản phẩm không được rỗng");

            var result = await _service.UpdateDetailAdjustmentAsync(headerId, details);

            if (result) return Ok("Cập nhật chi tiết hiệu chỉnh thành công");
            return StatusCode(500, "Lỗi khi cập nhật chi tiết");
        }
    }
}
