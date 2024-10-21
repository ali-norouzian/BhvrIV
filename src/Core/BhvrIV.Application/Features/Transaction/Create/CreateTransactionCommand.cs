using Mediator;

namespace BhvrIV.Application.Features.Product.Commands.Create;

public record CreateTransactionCommand(
    int ProductId,
    int WarehouseId,
    string TransactionType,
    int Quantity)
    : IRequest<CreateTransactionCommandResult>;