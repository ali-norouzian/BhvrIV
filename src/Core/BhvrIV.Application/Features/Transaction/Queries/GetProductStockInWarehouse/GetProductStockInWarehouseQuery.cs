using Mediator;

namespace BhvrIV.Application.Features.Transaction.Queries.GetProductStockInWarehouse;

public record GetProductStockInWarehouseQuery(
    int ProductId,
    int WarehouseId)
    : IRequest<GetProductStockInWarehouseQueryResult>;