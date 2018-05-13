using System.Reflection;
using Autofac;
using UserManager.Infrastructure.Services;

namespace UserManager.Infrastructure.IoC
{
    public class ServiceModule : Autofac.Module
    {
          protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                .As<IEncrypter>()
                .SingleInstance();
        }
    }
}