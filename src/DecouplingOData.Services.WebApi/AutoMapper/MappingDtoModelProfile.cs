using AutoMapper;
using DecouplingOData.Application.Dtos;
using DecouplingOData.Services.WebApi.DtoModels;

namespace DecouplingOData.Services.WebApi.AutoMapper
{
    public class MappingDtoModelProfile : Profile
    {
        public MappingDtoModelProfile()
        {
            DisableConstructorMapping();
            CreateMap<CategoryDtoModel,
                      CategoryDto>()
                .MaxDepth(1)
                .PreserveReferences()
                .ForPath(x => x.Parent, o => o.Ignore())
                .ReverseMap();
        }
    }
}