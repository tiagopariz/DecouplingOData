using System.Collections;
using DecouplingOData.Domain.Interfaces.Entities;
using DecouplingOData.Domain.Interfaces.Queries;
using DecouplingOData.Domain.Interfaces.Repositories;
using DecouplingOData.Domain.Interfaces.Services;
using Microsoft.AspNet.OData.Query;

namespace DecouplingOData.Domain.Services
{
    public class CategoryService : ICategoryService<ICategory>
    {
        private readonly ICategoryRepository<ICategory> _categoryRepository;
        private readonly ICategoryQuery _categoryQuery;

        public CategoryService(ICategoryRepository<ICategory> categoryRepository,
                               ICategoryQuery categoryQuery)
        {
            _categoryRepository = categoryRepository;
            _categoryQuery = categoryQuery;
        }

        public void Add(ICategory category)
        {
            _categoryRepository.Add(category);
        }

        public IEnumerable GetAll(ODataQueryOptions queryOptions)
        {
            return _categoryQuery.GetAll(queryOptions);
        }
    }
}