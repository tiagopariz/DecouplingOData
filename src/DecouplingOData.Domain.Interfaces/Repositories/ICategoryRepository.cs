using DecouplingOData.Domain.Interfaces.Entities;

namespace DecouplingOData.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository<T>
    {
        void Add(T category);        
    }
}