using System;

namespace DecouplingOData.Application.Dtos
{
    public class CategoryDto
    {
        protected CategoryDto() {}

        public CategoryDto(Guid id,
                           string description,
                           bool actived,
                           Guid? parentId,
                           CategoryDto parent,
                           DateTime registerDate)
        {
            Id = id;
            Description = description;
            ParentId = parentId;
            Parent = parent;
            RegisterDate = registerDate;
        }

        public CategoryDto(Guid id,
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
        public CategoryDto Parent { get; private set; }
        public DateTime RegisterDate { get; private set; }
    }
}