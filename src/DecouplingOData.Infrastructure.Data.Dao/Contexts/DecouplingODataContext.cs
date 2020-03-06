using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DecouplingOData.Domain.Interfaces.Contexts;
using DecouplingOData.Domain.Entities;

namespace DecouplingOData.Infrastructure.Data.Dao.Contexts
{
    public class DecouplingODataContext : DbContext, IDecouplingODataContext
    {
        public DecouplingODataContext()
        {
            var configurationFile = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile($"appsettings.json")
                    .Build();

            ConnectionString = configurationFile
                                    .GetConnectionString("DecouplingODataConnection");            
        }

        public string ConnectionString { get; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);            
            base.OnConfiguring(optionsBuilder);
        }       
    }
}