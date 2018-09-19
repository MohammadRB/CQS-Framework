using System;
using System.Linq;
using System.Reflection;
using CQS.Framework.App;
using CQS.Framework.Event;

namespace CQS.Framework.Bus
{
    public class EventBusRegistrar
    {
        public static void RegisterListeners(IServiceRegistrar serviceRegistrar, params Assembly[] assemblies)
        {
            var eventListenerType = typeof(EventListener<>);
            var assemblyTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();
            var eventListenerTypes = assemblyTypes
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .Where(t => t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == eventListenerType)
                .GroupBy(t => t.BaseType.GetGenericArguments().First())
                .ToList();

            foreach (var events in eventListenerTypes)
            {
                foreach (var listener in events)
                {
                    serviceRegistrar.Register(events.Key, listener);
                }
            }
        }
    }
}