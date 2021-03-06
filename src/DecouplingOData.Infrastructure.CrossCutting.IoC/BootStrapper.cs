﻿using DecouplingOData.Domain.Interfaces.Contexts;
using DecouplingOData.Domain.Interfaces.Queries;
using DecouplingOData.Domain.Interfaces.Repositories;
using DecouplingOData.Infrastructure.Data.Dao.Contexts;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using DecouplingOData.Domain.Interfaces.Entities;
using DecouplingOData.Infrastructure.Data.Dao.Queries;

namespace DecouplingOData.Infrastructure.CrossCutting.Ioc
{
    public class BootStrapper
    {
        public void RegisterServices(Container container)
        {
            if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
           
            container.Register<IDecouplingODataContext, DecouplingODataContext>(Lifestyle.Scoped);
            container.Register<ICategoryQuery, CategoryQuery>(Lifestyle.Scoped);
            container.Register<ICategoryRepository<ICategory>, CategoryRepository>(Lifestyle.Scoped);
        }
    }
}