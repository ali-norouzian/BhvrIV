using Mediator;

namespace BhvrIV.Application.Features.Product.Commands.Create;

public record CreateProductCommand(
    string Name,
    decimal Price,
    int StockQuantity)
    : IRequest<CreateProductCommandResult>;