using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CQS.Framework.App;
using CQS.Framework.Event;

namespace CQS.Framework.Bus
{
    public class EventBusRegister
    {
        public static void RegisterListeners(IServiceRegistrar serviceRegistrar, params Assembly[] assemblies)
        {
            var eventListenerType = typeof(EventListener<>);
            var assemblyTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();
            var eventListenerTypes = assemblyTypes
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .Select
                (
                    t =>
                    {
                        var currentBase = t.BaseType;

                        while (currentBase != null)
                        {
                            if (currentBase.IsGenericType &&
                                currentBase.GetGenericTypeDefinition() == eventListenerType)
                            {
                                break;
                            }

                            currentBase = currentBase.BaseType;
                        }

                        return new Tuple<Type, Type>(t, currentBase);
                    }
                )
                .Where(t => t.Item2 != null)
                .ToList()
                .GroupBy(el => el.Item2.GenericTypeArguments.First());

            foreach (var events in eventListenerTypes)
            {
                foreach (var listener in events)
                {
                    serviceRegistrar.Register(events.Key, listener.Item1);
                }
            }
        }
    }
}