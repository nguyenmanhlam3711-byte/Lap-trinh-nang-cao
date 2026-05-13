using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLySinhVien.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViDu1Controller : ControllerBase
    {
        [HttpGet("cong")]
        public IActionResult Cong()
        {
            int a = 1, b = 2, c = a + b;

            return Ok(c);
        }
    }
}
