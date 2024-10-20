using AutoMapper;
using BhvrIV.Domain.Entities;
using Codal.Application.Features.BasicInfo.Services.Commands.Create;

namespace BhvrIV.Application.Mappers;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Can be automated ...

        CreateMap<CreateProductCommand, Products>();
    }
}
