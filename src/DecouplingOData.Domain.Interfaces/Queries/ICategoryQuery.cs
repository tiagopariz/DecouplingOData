using System.Collections;
using Microsoft.AspNet.OData.Query;

namespace DecouplingOData.Domain.Interfaces.Queries
{
    public interface ICategoryQuery
    {
        IEnumerable GetAll(ODataQueryOptions queryOptions);
    }
}