using System;

namespace DecouplingOData.Services.WebApi.DtoModels
{
    public class CategoryDtoModel
    {
        protected CategoryDtoModel() {}

        public CategoryDtoModel(Guid id,
                                string description,
                                bool actived,
                                Guid? parentId,
                                CategoryDtoModel parent,
                                DateTime registerDate)
        {
            Id = id;
            Description = description;
            ParentId = parentId;
            Parent = parent;
            RegisterDate = registerDate;
        }

        public CategoryDtoModel(Guid id,
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
        public CategoryDtoModel Parent { get; private set; }
        public DateTime RegisterDate { get; private set; }
    }
}