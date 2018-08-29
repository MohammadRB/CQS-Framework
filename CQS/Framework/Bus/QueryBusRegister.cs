using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CQS.Framework.Query;

namespace CQS.Framework.Bus
{
    public class QueryBusRegister
    {
        public static QueryBus Instance { get; set; }

        public static QueryBus RegisterBuilders(Assembly assembly)
        {
            var queryBuilders = new Dictionary<Type, IQueryBuilder>();
            var queryBuilderType = typeof(QueryBuilder<>);
            var assemblyTypes = assembly.GetTypes();
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
                var queryType = builderType.Item2.GenericTypeArguments.ElementAt(1);

                queryBuilders.Add
                (
                    queryType,
                    (IQueryBuilder) Activator.CreateInstance(builderType.Item1)
                );
            }

            return new QueryBus(queryBuilders);
        }
    }
}