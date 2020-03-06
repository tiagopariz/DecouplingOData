using DecouplingOData.Domain.Entities;
using DecouplingOData.Domain.Interfaces.Contexts;
using DecouplingOData.Domain.Interfaces.Entities;
using DecouplingOData.Infrastructure.Data.Dao.Contexts;

namespace DecouplingOData.Domain.Interfaces.Repositories
{
    public class CategoryRepository : ICategoryRepository<ICategory>
    {
        private readonly DecouplingODataContext _context;

        public CategoryRepository(IDecouplingODataContext context)
        {
            _context = (DecouplingODataContext) context;
        }

        public void Add(ICategory category)
        {
            _context.Categories.Add(category as Category);
        }
    }
}