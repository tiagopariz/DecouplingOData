using AutoMapper;

namespace DecouplingOData.Services.WebApi.AutoMapper
{
    public class AutoMapperDtoModelConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void RegisterMappings()
        {
            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingDtoModelProfile());
            });

            Mapper = mappingConfig.CreateMapper();
        }
    }
}