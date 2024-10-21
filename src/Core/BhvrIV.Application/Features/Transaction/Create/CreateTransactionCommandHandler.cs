using AutoMapper;
using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities;
using Mediator;

namespace BhvrIV.Application.Features.Transaction.Create;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, CreateTransactionCommandResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async ValueTask<CreateTransactionCommandResult> Handle(
        CreateTransactionCommand request,
        CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.GetRepository<Transactions>();

        //var transactions = _mapper.Map<Transactions>(request);

        // For ef core: 
        //await repo.Add(transactions);
        //await _unitOfWork.SaveChanges();

        // For sp sql:
        await repo.ExecuteStoredProcedure("sp_AddNewTransaction", request);

        return new CreateTransactionCommandResult(0);
    }
}