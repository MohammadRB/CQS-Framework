using System;
using System.Linq;
using System.Reflection;
using CQS.Framework.App;
using CQS.Framework.Query;

namespace CQS.Framework.Bus
{
    public class QueryBusRegister
    {
        public static void RegisterBuilders(IServiceRegistrar serviceRegistrar, params Assembly[] assemblies)
        {
            var queryBuilderType = typeof(QueryBuilder<>);
            var assemblyTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();
            var queryBuilderTypes = assemblyTypes
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .Select
                (
                    t =>
                    {
                        var currentBase = t.BaseType;

                        while (currentBase != null)
                        {
                            if (currentBase.IsGenericType &&
                                currentBase.GetGenericTypeDefinition() == queryBuilderType)
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

            foreach (var builderType in queryBuilderTypes)
            {
                var queryType = builderType.Item2.GenericTypeArguments.First();

                serviceRegistrar.Register(queryType, builderType.Item1);
            }
        }
    }
}