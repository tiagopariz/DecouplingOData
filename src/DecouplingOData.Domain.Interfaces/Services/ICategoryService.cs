using System.Collections;
using Microsoft.AspNet.OData.Query;

namespace DecouplingOData.Domain.Interfaces.Services
{
    public interface ICategoryService<T>
    {
        IEnumerable GetAll(ODataQueryOptions queryOptions);
        void Add(T category);
    }
}