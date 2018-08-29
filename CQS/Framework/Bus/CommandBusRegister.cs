using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CQS.Framework.Command;

namespace CQS.Framework.Bus
{
    public class CommandBusRegister
    {
        public static CommandBus Instance { get; set; }

        public static CommandBus RegisterHandlers(Assembly assembly)
        {
            var result = new Dictionary<Type, ICommandHandler>();
            var commandHandlerTypes = new[]
            {
                typeof(CommandHandler<>),
                typeof(CommandHandler<,>),
                typeof(CommandHandler<,,>),
                typeof(CommandHandler<,,,>)
            };

            var assemblyTypes = assembly.GetTypes();
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
                var commandHandler = (ICommandHandler) Activator.CreateInstance(handlerType.Item1);
                var commandTypes = handlerType.Item2.GenericTypeArguments
                    .Skip(1)
                    .ToList();

                foreach (var commandType in commandTypes)
                {
                    result.Add(commandType, commandHandler);
                }
            }

            return new CommandBus(result);
        }
    }
}