using System.Reflection;
using CQS.Extensions.DependencyInjection;
using CQS.Framework.App;
using CQS.Framework.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace CQS.Extensions.NetInjection
{
    public static class Extensions
    {
        public static IServiceCollection AddCQSFramework(this IServiceCollection serviceCollection, params Assembly[] assemblies)
        {
            var serviceRegistrar = new FrameworkServiceRegistrar(serviceCollection);
            CommandBusRegistrar.RegisterHandlers(serviceRegistrar, assemblies);
            QueryBusRegistrar.RegisterBuilders(serviceRegistrar, assemblies);
            EventBusRegistrar.RegisterListeners(serviceRegistrar, assemblies);

            serviceCollection.AddTransient<IServiceLocator, FrameworkServiceLocator>();
            serviceCollection.AddScoped<ICommandBus, CommandBus>();
            serviceCollection.AddScoped<IQueryBus, QueryBus>();
            serviceCollection.AddScoped<IEventBus, EventBus>();
            serviceCollection.AddScoped<AppDispatcher, AppDispatcher>();

            return serviceCollection;
        }
    }
}