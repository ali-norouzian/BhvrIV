using Mediator;

namespace BhvrIV.Application.Features.Transaction.Queries;

public record GetProductStockInWarehouseQuery(
    int ProductId,
    int WarehouseId)
    : IRequest<GetProductStockInWarehouseQueryResult>;