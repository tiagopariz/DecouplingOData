using DecouplingOData.Domain.Interfaces.Entities;
using DecouplingOData.Domain.Interfaces.Services;
using DecouplingOData.Domain.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace DecouplingOData.Application.IoC
{
    public class BootStrapper
    {
        public void RegisterServices(Container container)
        {
            if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            var domainBootStrapper = new DecouplingOData.Infrastructure.CrossCutting.Ioc.BootStrapper();
            domainBootStrapper.RegisterServices(container);

            container.Register<ICategoryService<ICategory>, CategoryService>(Lifestyle.Scoped);
        }
    }
}