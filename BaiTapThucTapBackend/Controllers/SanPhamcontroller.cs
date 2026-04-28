using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucTapBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SanPhamcontroller : ControllerBase
    {
        private readonly ISanPhamService _service;
        public SanPhamcontroller(ISanPhamService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAll();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSanPhamRequest request)
        {
            var result = await _service.Create(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateSanPhamRequest request)
        {
            var result = await _service.Update(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
