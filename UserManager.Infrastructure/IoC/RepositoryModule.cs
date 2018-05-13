using System.Reflection;
using Autofac;
using UserManager.Core.Repositories;

namespace UserManager.Infrastructure.IoC
{
    public class RepositoryModule : Autofac.Module
    {
          protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}