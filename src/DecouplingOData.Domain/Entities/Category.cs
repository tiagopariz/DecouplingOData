using System;
using DecouplingOData.Domain.Interfaces.Entities;

namespace DecouplingOData.Domain.Entities
{
    public class Category : ICategory
    {
        public Category(Guid? id,
                        string description,
                        bool actived,
                        Guid? parentId,
                        Category parent,
                        DateTime registerDate)
        {
            Id = id ?? Guid.NewGuid();
            Description = description;
            ParentId = parentId;
            Parent = parent;
            RegisterDate = registerDate;
        }

        public Category(Guid id,
                        string description,
                        bool actived,
                        Guid? parentId,
                        DateTime registerDate)
        {
            Id = id;
            Description = description;
            ParentId = parentId;
            RegisterDate = registerDate;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public bool Actived { get; private set; }
        public Guid? ParentId { get; private set; }
        public Category Parent { get; private set; }
        public DateTime RegisterDate { get; private set; }
    }
}