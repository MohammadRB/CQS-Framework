using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CQS.Framework.App;
using CQS.Framework.Command;

namespace CQS.Framework.Bus
{
    public class CommandBusRegister
    {
        public static void RegisterHandlers(IServiceRegistrar serviceRegistrar, params Assembly[] assemblies)
        {
            var commandHandlerTypes = new[]
            {
                typeof(CommandHandler<>),
                typeof(CommandHandler<,>),
                typeof(CommandHandler<,,>),
                typeof(CommandHandler<,,,>)
            };
            var assemblyTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();
            var commandHandlers = assemblyTypes
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .Select
                (
                    t =>
                    {
                        var currentBase = t.BaseType;

                        while (currentBase != null)
                        {
                            if (currentBase.IsGenericType &&
                                commandHandlerTypes.Any(ct => currentBase.GetGenericTypeDefinition() == ct))
                            {
                                break;
                            }

                            currentBase = currentBase.BaseType;
                        }

                        return new Tuple<Type, Type>(t, currentBase);
                    }
                )
                .Where(t => t.Item2 != null)
                .ToList();

            foreach (var handlerType in commandHandlers)
            {
                var commandTypes = handlerType.Item2.GenericTypeArguments.ToList();

                foreach (var commandType in commandTypes)
                {
                    serviceRegistrar.Register(commandType, handlerType.Item1);
                }
            }
        }
    }
}