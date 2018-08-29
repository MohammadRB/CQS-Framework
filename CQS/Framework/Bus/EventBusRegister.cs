using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CQS.Framework.Event;

namespace CQS.Framework.Bus
{
    public class EventBusRegister
    {
        public static EventBus Instance { get; set; }

        public static EventBus RegisterListeners(Assembly assembly)
        {
            var eventListeners = new Dictionary<Type, List<IEventListener>>();
            var eventListenerType = typeof(EventListener<>);
            var assemblyTypes = assembly.GetTypes();
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
                .GroupBy(el => el.Item2.GenericTypeArguments.ElementAt(1));

            foreach (var listenerType in eventListenerTypes)
            {
                eventListeners.Add
                (
                    listenerType.Key,
                    listenerType.Select(elt => (IEventListener) Activator.CreateInstance(elt.Item1)).ToList()
                );
            }

            return new EventBus(eventListeners);
        }
    }
}