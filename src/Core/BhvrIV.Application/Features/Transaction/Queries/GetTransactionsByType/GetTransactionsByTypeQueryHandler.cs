using AutoMapper;
using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities;
using Mediator;

namespace BhvrIV.Application.Features.Transaction.Queries.GetProductStockInWarehouse;

public class GetTransactionsByTypeQueryHandler : IRequestHandler<GetTransactionsByTypeQuery, List<GetTransactionsByTypeQueryResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTransactionsByTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async ValueTask<List<GetTransactionsByTypeQueryResult>> Handle(
        GetTransactionsByTypeQuery request,
        CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.GetRepository<Transactions>();

        //var transactions = _mapper.Map<Transactions>(request);

        // For ef core: 
        //var efResult = await repo.List(e => e.TransactionType == (TransactionType)Enum.Parse(typeof(TransactionType), request.TransactionType));
        //await _unitOfWork.SaveChanges();

        // For sp sql:
        var spResult = await repo.ExecuteStoredProcedure("sp_GetTransactionsByType", request);

        var transactions = _mapper.Map<List<GetTransactionsByTypeQueryResult>>(spResult);

        return transactions;
    }
}