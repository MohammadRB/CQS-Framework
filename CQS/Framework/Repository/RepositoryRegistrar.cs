using System;
using System.Linq;
using System.Reflection;
using CQS.Framework.App;

namespace CQS.Framework.Repository
{
    public class RepositoryRegistrar
    {
        public static void RegisterRepositories(IServiceRegistrar serviceRegistrar, params Assembly[] assemblies)
        {
            var assemblyTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();
            var repositoryTypes = assemblyTypes
                .Where(t => t.IsInterface)
                .Where(t => t.GetInterfaces()
                    .Any(i => i == typeof(IReadRepository) ||
                              (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IWriteRepository<>)))
                )
                .ToList();
            var repositories = assemblyTypes
                .Where(t => !t.IsAbstract && !t.IsInterface && t.GetInterfaces().Any(i => repositoryTypes.Contains(i)))
                .ToList();

            foreach (var repositoryType in repositories)
            {
                var implementedRepositories = repositoryType.GetInterfaces().Where(i => repositoryTypes.Contains(i));
                foreach (var implementedRepository in implementedRepositories)
                {
                    serviceRegistrar.Register(implementedRepository, repositoryType);
                }
            }
        }
    }
}