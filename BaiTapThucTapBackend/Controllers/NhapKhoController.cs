using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucTapBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhapKhoController : ControllerBase
    {
        private readonly INhapKhoService _service;

        public NhapKhoController(INhapKhoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int userKhoId, bool isAdmin)
        {
            return Ok(await _service.GetAll( userKhoId, isAdmin));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNhapKhoRequest request)
        {
            return Ok(await _service.Create(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPut("details/{id}")]
        public async Task<IActionResult> UpdateDetails(int id, NhapKhoDetailDto entity)
        {
            await _service.UpdateDetails(id, entity);
			return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpGet("bao-cao-chi-tiet-hang-nhap")]
        public async Task<IActionResult> BaoCaoChiTietHangNhap([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int userKhoId, [FromQuery] bool isAdmin)
        {
            return Ok(await _service.BaoCaoChiTietHangNhap(startDate, endDate, userKhoId, isAdmin));
        }
    }
}
