using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Application.Features.Sinhvien.Commands.Create;

namespace QuanLySinhVien.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SinhVienController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SinhVienController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSinhVienCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}