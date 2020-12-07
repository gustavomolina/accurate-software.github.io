using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Repository.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ifound_api
{
    public interface ISGPDataEntityTypesConfiguration<TEntityType> : IEntityTypeConfiguration<TEntityType> where TEntityType : class { }

    public class SGPDataDbContext : DbContext
    {
        private IConfiguration Configuration { get; }

        public SGPDataDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
            .UseLazyLoadingProxies()
            .UseSqlServer(Configuration.GetConnectionString("SGPData"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddEntityMappings(modelBuilder);
        }

        private void AddEntityMappings(ModelBuilder modelBuilder)
        {
            foreach (var type in GetAllAssemblyMap())
            {
                modelBuilder.ApplyConfiguration((dynamic)Activator.CreateInstance(type));
            }
        }

        private IEnumerable<Type> GetAllAssemblyMap()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                           .Where(p => p.GetInterfaces()
                                        .Where(c => c.IsGenericType &&
                                                c.GetGenericTypeDefinition() == typeof(ISGPDataEntityTypesConfiguration<>))
                                                .Any());
        }
    }

    public class SGPDataUnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }

        public SGPDataUnitOfWork(SGPDataDbContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }

}