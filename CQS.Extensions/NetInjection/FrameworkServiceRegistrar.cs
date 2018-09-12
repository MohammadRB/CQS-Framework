using System;
using Microsoft.Extensions.DependencyInjection;
using CQS.Framework.App;

namespace CQS.Extensions.DependencyInjection
{
    public class FrameworkServiceRegistrar : IServiceRegistrar
    {
        public FrameworkServiceRegistrar(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public void Register(Type type, Type concrete)
        {
            _serviceCollection.AddTransient(type, concrete);
        }

        private readonly IServiceCollection _serviceCollection;
    }
}