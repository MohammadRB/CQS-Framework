using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Event;

namespace CQS.Framework.Bus
{
    public interface IEventBus
    {
        uint Publish<TBoundedContext, TEvent>(TBoundedContext appBoundedContext, TEvent @event)
            where TBoundedContext : IAppBoundedContext
            where TEvent : IEvent;

        Task<uint> PublishAsync<TBoundedContext, TEvent>(TBoundedContext appBoundedContext, TEvent @event)
            where TBoundedContext : IAppBoundedContext
            where TEvent : IEvent;
    }
}