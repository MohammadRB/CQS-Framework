using System;

namespace CQS.Framework.App
{
    public interface IServiceRegistrar
    {
        void Register(Type type, Type concrete);
    }
}