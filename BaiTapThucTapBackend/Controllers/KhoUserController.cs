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

        [HttpGet("{Ma_Dang_Nhap}")]
        public async Task<IActionResult> GetByUser(string Ma_Dang_Nhap)
        {
            return Ok(await _service.GetByUser(Ma_Dang_Nhap));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateKhoUserRequest request)
        {
            await _service.Create(request);
            return Ok("Tao thanh cong");
        }

        [HttpDelete("{Ma_Dang_Nhap}/{Kho_ID}")]
        public async Task<IActionResult> Delete(string Ma_Dang_Nhap, int Kho_ID)
        {
            await _service.Delete(Ma_Dang_Nhap, Kho_ID);
            return Ok("Xoa thanh cong");
        }
    }
}
