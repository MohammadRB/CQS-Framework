using System;
using System.Collections.Generic;
using System.Linq;
using CQS.Framework.App;

namespace CQS.Framework.DefaultImp
{
    public class DefaultServiceLocator : IServiceRegistrar, IServiceLocator
    {
        public DefaultServiceLocator()
        {
            _map = new Dictionary<Type, List<Type>>();
        }

        public void Register(Type type, Type concrete)
        {
            if (!_map.ContainsKey(type))
            {
                _map.Add(type, new List<Type>()
                {
                    concrete
                });
            }
            else
            {
                _map[type].Add(concrete);
            }
        }

        public IEnumerable<TConcrete> Get<TType, TConcrete>()
        {
            var types = _map[typeof(TType)];
            return types.Select(Activator.CreateInstance)
                .Cast<TConcrete>()
                .ToList();
        }

        private readonly Dictionary<Type, List<Type>> _map;
    }
}