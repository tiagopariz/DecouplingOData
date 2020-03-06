using System;

namespace DecouplingOData.Domain.Interfaces.Entities
{
    public interface ICategory
    {
        Guid Id { get; }
        string Description { get; }
        bool Actived { get; }
        Guid? ParentId { get; }
        DateTime RegisterDate { get; }
    }
}