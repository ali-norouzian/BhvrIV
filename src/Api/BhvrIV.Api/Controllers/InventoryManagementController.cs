using Codal.Application.Features.BasicInfo.Services.Commands.Create;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace BhvrIV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("product")]
        public async Task<IActionResult> AddNewProduct(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
