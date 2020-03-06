using AutoMapper;

namespace DecouplingOData.Application.AutoMapper
{
    public class AutoMapperDtoConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void RegisterMappings()
        {
            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingDtoProfile());
            });

            Mapper = mappingConfig.CreateMapper();
        }
    }
}