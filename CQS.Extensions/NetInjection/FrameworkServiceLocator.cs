using System;
using System.Collections.Generic;
using CQS.Framework.App;
using Microsoft.Extensions.DependencyInjection;

namespace CQS.Extensions.DependencyInjection
{
    public class FrameworkServiceLocator : IServiceLocator
    {
        public FrameworkServiceLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<TType> Get<TType>()
        {
            var services = _serviceProvider.GetServices<TType>();
            return services;
        }

        private readonly IServiceProvider _serviceProvider;
    }
}