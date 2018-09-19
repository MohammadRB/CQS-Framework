using System;
using System.Linq;
using System.Reflection;
using CQS.Framework.App;
using CQS.Framework.Command;

namespace CQS.Framework.Bus
{
    public class CommandBusRegistrar
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
                .Where(t => t.BaseType.IsGenericType && commandHandlerTypes.Any(ct => t.BaseType.GetGenericTypeDefinition() == ct))
                .ToList();

            foreach (var handlerType in commandHandlers)
            {
                var commandTypes = handlerType.BaseType.GenericTypeArguments.ToList();
                foreach (var commandType in commandTypes)
                {
                    serviceRegistrar.Register(typeof(ICommandHandler<>).MakeGenericType(commandType), handlerType);
                }
            }
        }
    }
}