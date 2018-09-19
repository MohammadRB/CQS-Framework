using System;
using System.Linq;
using System.Reflection;
using CQS.Framework.App;
using CQS.Framework.Query;

namespace CQS.Framework.Bus
{
    public class QueryBusRegistrar
    {
        public static void RegisterBuilders(IServiceRegistrar serviceRegistrar, params Assembly[] assemblies)
        {
            var queryBuilderType = typeof(QueryBuilder<>);
            var assemblyTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();
            var queryBuilderTypes = assemblyTypes
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .Where(t => t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == queryBuilderType)
                .ToList();

            foreach (var builderType in queryBuilderTypes)
            {
                serviceRegistrar.Register(typeof(IQueryBuilder<>).MakeGenericType(builderType.BaseType.GetGenericArguments().First()), builderType);
            }
        }
    }
}