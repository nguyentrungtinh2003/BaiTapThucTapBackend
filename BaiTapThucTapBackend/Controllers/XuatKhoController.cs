using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucTapBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XuatKhoController : ControllerBase
    {
        private readonly IXuatKhoService _service;

        public XuatKhoController(IXuatKhoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPut("details/{id}")]
        public async Task<IActionResult> UpdateDetails(int id, XuatKhoDetailDto entity)
        {
            await _service.UpdateDetails(id, entity);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateXuatKhoRequest request)
        {
            return Ok(await _service.Create(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
