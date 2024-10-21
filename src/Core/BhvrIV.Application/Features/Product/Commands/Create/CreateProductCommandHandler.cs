using AutoMapper;
using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities;
using Mediator;

namespace BhvrIV.Application.Features.Product.Commands.Create;

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

        //var product = _mapper.Map<Products>(request);

        // For ef core: 
        //await repo.Add(product);
        //await _unitOfWork.SaveChanges();

        // For sp sql:
        var insertedId = (await repo.ExecuteStoredProcedure("sp_AddNewProduct", request)).FirstOrDefault().Id;

        return new CreateProductCommandResult(insertedId);
    }
}