using AutoMapper;
using BhvrIV.Application.Features.Product.Commands.Create;
using BhvrIV.Application.Features.Transaction.Queries.GetProductStockInWarehouse;
using BhvrIV.Domain.Entities;

namespace BhvrIV.Application.Mappers;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Can be automated ...

        CreateMap<CreateProductCommand, Products>();
        CreateMap<Transactions, GetTransactionsByTypeQueryResult>();
    }
}
