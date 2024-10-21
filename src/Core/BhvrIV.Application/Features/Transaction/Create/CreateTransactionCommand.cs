using Mediator;

namespace BhvrIV.Application.Features.Transaction.Create;

public record CreateTransactionCommand(
    int ProductId,
    int WarehouseId,
    string TransactionType,
    int Quantity)
    : IRequest<CreateTransactionCommandResult>;