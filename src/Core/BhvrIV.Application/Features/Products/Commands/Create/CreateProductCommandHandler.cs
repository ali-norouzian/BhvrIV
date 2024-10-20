using AutoMapper;
using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities;
using Mediator;

namespace Codal.Application.Features.BasicInfo.Services.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async ValueTask<CreateProductCommandResult> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.GetRepository<Products>();

        var product = _mapper.Map<Products>(request);
        await repo.Add(product);

        await _unitOfWork.SaveChanges();

        return new CreateProductCommandResult(product.Id);
    }
}