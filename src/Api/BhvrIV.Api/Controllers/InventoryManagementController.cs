using BhvrIV.Application.Features.Product.Commands.Create;
using BhvrIV.Application.Features.Transaction.Commands.Create;
using BhvrIV.Application.Features.Transaction.Queries.GetProductStockInWarehouse;
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

        [HttpGet("transaction/product/{productId}/stock/warehouse/{warehouseId}")]
        public async Task<IActionResult> GetProductStockInWarehouse(int productId, int warehouseId)
        {
            var query = new GetProductStockInWarehouseQuery(productId, warehouseId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("transaction/{transactionType}")]
        public async Task<IActionResult> GetTransactionsByType(string transactionType)
        {
            var query = new GetTransactionsByTypeQuery(transactionType);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
