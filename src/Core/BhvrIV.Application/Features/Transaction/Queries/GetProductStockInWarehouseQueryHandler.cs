using AutoMapper;
using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities;
using Mediator;

namespace BhvrIV.Application.Features.Transaction.Queries;

public class GetProductStockInWarehouseQueryHandler : IRequestHandler<GetProductStockInWarehouseQuery, GetProductStockInWarehouseQueryResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductStockInWarehouseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async ValueTask<GetProductStockInWarehouseQueryResult> Handle(
        GetProductStockInWarehouseQuery request,
        CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.GetRepository<Products>();

        //var transactions = _mapper.Map<Transactions>(request);

        // For ef core: 
        //await repo.Add(transactions);
        //await _unitOfWork.SaveChanges();

        // For sp sql:
        var spResult = await repo.ExecuteStoredProcedure("sp_GetProductStockInWarehouse", request);

        return new GetProductStockInWarehouseQueryResult(spResult.FirstOrDefault().StockQuantity);
    }
}