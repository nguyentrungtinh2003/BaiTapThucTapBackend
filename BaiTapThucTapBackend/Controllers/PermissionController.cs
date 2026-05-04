using BaiTapThucTapBackend.Data;
using BaiTapThucTapBackend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public PermissionController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] PermissionDto permissionDto)
        {
            var exists = _context.KhoUsers
                .Any(x => x.Ma_Dang_Nhap == permissionDto.Ma_Dang_Nhap && x.Kho_ID == permissionDto.Kho_ID);

            if (!exists)
                return Forbid();

            return Ok(new
            {
                Ma_Dang_Nhap = permissionDto.Ma_Dang_Nhap,
                isAdmin = permissionDto.Ma_Dang_Nhap.ToLower() == "admin",
                Kho_ID = permissionDto.Kho_ID,
            });
        }
    }
}
