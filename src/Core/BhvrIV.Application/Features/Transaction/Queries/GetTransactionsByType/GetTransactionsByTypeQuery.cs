using Mediator;

namespace BhvrIV.Application.Features.Transaction.Queries.GetProductStockInWarehouse;

public record GetTransactionsByTypeQuery(
    string TransactionType)
    : IRequest<List<GetTransactionsByTypeQueryResult>>;