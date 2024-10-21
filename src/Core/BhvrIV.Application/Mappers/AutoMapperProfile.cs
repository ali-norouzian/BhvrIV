using AutoMapper;
using BhvrIV.Application.Features.Product.Commands.Create;
using BhvrIV.Domain.Entities;

namespace BhvrIV.Application.Mappers;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Can be automated ...

        CreateMap<CreateProductCommand, Products>();
    }
}
