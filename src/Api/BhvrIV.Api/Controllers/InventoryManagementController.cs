using BhvrIV.Application.Features.Product.Commands.Create;
using BhvrIV.Application.Features.Transaction.Create;
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

        [HttpPost("transaction")]
        public async Task<IActionResult> AddNewTransactions(CreateTransactionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
