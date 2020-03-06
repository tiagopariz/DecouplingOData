using AutoMapper;
using DecouplingOData.Application.Dtos;
using DecouplingOData.Domain.Interfaces.Entities;

namespace DecouplingOData.Application.AutoMapper
{
    public class MappingDtoProfile : Profile
    {
        public MappingDtoProfile()
        {
            DisableConstructorMapping();
            CreateMap<ICategory, CategoryDto>()
                .MaxDepth(1)
                .ReverseMap()
                .PreserveReferences();
        }
    }
}