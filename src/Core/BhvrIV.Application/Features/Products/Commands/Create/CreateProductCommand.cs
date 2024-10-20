using Mediator;

namespace Codal.Application.Features.BasicInfo.Services.Commands.Create;

public record CreateProductCommand(
    string Name,
    decimal Price,
    int StockQuantity)
    : IRequest<CreateProductCommandResult>;