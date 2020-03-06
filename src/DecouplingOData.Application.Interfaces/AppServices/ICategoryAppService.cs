using System.Collections;
using Microsoft.AspNet.OData.Query;

namespace DecouplingOData.Application.Interfaces.AppServices
{
    public interface ICategoryAppService<T>
    {
        IEnumerable GetAll(ODataQueryOptions queryOptions);
        void Add(T category);
    }
}