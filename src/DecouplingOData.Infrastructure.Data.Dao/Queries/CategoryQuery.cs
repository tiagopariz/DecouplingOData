using System.Collections;
using DecouplingOData.Domain.Entities;
using DecouplingOData.Domain.Interfaces.Contexts;
using DecouplingOData.Domain.Interfaces.Queries;
using DecouplingOData.Infrastructure.Data.Dao.Contexts;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Query;
using Microsoft.OData.Edm;

namespace DecouplingOData.Infrastructure.Data.Dao.Queries
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly DecouplingODataContext _context;

        public CategoryQuery(IDecouplingODataContext context)
        {
            _context = (DecouplingODataContext) context;
        }

        public IEnumerable GetAll(ODataQueryOptions queryOptions)
        {
            var oDataQueryContext = new ODataQueryContext(GetEdmModel(), typeof(Category), queryOptions.Context.Path);
            var entityQueryOptions = new ODataQueryOptions<Category>(oDataQueryContext, queryOptions.Request);
            var query = entityQueryOptions.ApplyTo(_context.Categories.AsQueryable());
            return _context.Categories.AsQueryable();
        }

        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            var categories = odataBuilder.EntitySet<Category>("Categories");
            categories.EntityType.HasKey(x => x.Id);
            categories.EntityType.Property(x => x.Actived);
            categories.EntityType.Property(x => x.Description);
            categories.EntityType.Property(x => x.ParentId);
            categories.EntityType.Property(x => x.RegisterDate);
            categories.EntityType.Select();
            return odataBuilder.GetEdmModel();
        }
    }
}