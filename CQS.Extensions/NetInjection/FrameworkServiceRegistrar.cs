using System;
using CQS.Framework.App;
using Microsoft.Extensions.DependencyInjection;

namespace CQS.Extensions.NetInjection
{
    public class FrameworkServiceRegistrar : IServiceRegistrar
    {
        public FrameworkServiceRegistrar(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public void Register(Type type, Type implementation)
        {
            _serviceCollection.AddTransient(type, implementation);
        }

        private readonly IServiceCollection _serviceCollection;
    }
}