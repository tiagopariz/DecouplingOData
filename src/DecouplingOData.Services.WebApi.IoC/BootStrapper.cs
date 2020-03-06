using DecouplingOData.Application.AppServices;
using DecouplingOData.Application.Dtos;
using DecouplingOData.Application.Interfaces.AppServices;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace DecouplingOData.Services.WebApi.IoC
{
    public class BootStrapper
    {
        public void RegisterServices(Container container)
        {
            if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var appBootStrapper = new DecouplingOData.Application.IoC.BootStrapper();
            appBootStrapper.RegisterServices(container);
            
            container.Register<ICategoryAppService<CategoryDto>, CategoryAppService>(Lifestyle.Scoped);
        }
    }
}