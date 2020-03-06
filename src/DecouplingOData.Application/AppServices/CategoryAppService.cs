using System.Collections;
using AutoMapper;
using DecouplingOData.Application.AutoMapper;
using DecouplingOData.Application.Dtos;
using DecouplingOData.Application.Interfaces.AppServices;
using DecouplingOData.Domain.Interfaces.Entities;
using DecouplingOData.Domain.Interfaces.Services;
using Microsoft.AspNet.OData.Query;

namespace DecouplingOData.Application.AppServices
{
    public class CategoryAppService : ICategoryAppService<CategoryDto>
    {
        private readonly ICategoryService<ICategory> _categoryService;
        private IMapper Mapper;

        public CategoryAppService(ICategoryService<ICategory> categoryService)
        {
            _categoryService = categoryService;
            SetMapper(new MappingDtoProfile());
        }

        public IEnumerable GetAll(ODataQueryOptions queryOptions)
        {
            var categories = _categoryService.GetAll(queryOptions);
            return categories;
        }

        public void Add(CategoryDto category)
        {
            _categoryService.Add(Mapper.Map<CategoryDto, ICategory>(category));
        }

        private void SetMapper(Profile mappingDtoProfile)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(mappingDtoProfile);
            });

            var mapper = mappingConfig.CreateMapper();
            Mapper = mapper;
        }
    }
}