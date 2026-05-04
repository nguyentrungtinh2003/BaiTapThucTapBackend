using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucTapBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhoUserController : ControllerBase
    {
        private readonly IKhoUserService _service;

        public KhoUserController(IKhoUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateKhoUserRequest request)
        {
            var error = await _service.Create(request);
            if(error != null)
            {
                return BadRequest(error);
            }
            return Ok("Tao thanh cong");
        }

        [HttpDelete("{MaDangNhap}/{KhoID}")]
        public async Task<IActionResult> Delete(string MaDangNhap, int KhoID)
        {
            await _service.Delete(MaDangNhap, KhoID);
            return Ok("Xoa thanh cong");
        }
    }
}
