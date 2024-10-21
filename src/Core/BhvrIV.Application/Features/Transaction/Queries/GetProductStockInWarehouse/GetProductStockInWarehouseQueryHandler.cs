using AutoMapper;
using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Domain.Entities;
using Mediator;

namespace BhvrIV.Application.Features.Transaction.Queries.GetProductStockInWarehouse;

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
        // For sp
        var repo = _unitOfWork.GetRepository<Products>();
        // For ef
        //var repo = _unitOfWork.GetRepository<Transactions>();

        //var transactions = _mapper.Map<Transactions>(request);

        // For ef core: 
        //var productStock = (await repo.First(
        //    e => e.ProductId == request.ProductId && e.WarehouseId == request.WarehouseId,
        //    new List<System.Linq.Expressions.Expression<Func<Transactions, object>>> { e => e.Product }))
        //    .Product.StockQuantity;
        //await _unitOfWork.SaveChanges();

        // For sp sql:
        var spResult = await repo.ExecuteStoredProcedure("sp_GetProductStockInWarehouse", request);

        return new GetProductStockInWarehouseQueryResult(spResult.FirstOrDefault().StockQuantity);
    }
}