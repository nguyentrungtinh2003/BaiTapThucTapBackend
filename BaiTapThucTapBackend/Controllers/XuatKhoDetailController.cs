using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucTapBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XuatKhoDetailController : ControllerBase
    {
        private readonly IXuatKhoDetailService _service;

        public XuatKhoDetailController(IXuatKhoDetailService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(XuatKhoDetail entity)
        {
            await _service.Create(entity);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, XuatKhoDetail entity)
        {
            await _service.Update(id, entity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
