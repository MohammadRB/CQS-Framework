using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Event;

namespace CQS.Framework.App
{
    class AppHubBoundedContextInstance
    {
        public Func<IExternalEventPublisher, IAppBoundedContext> Factory { get; private set; }
        public IAppBoundedContext BoundedContext { get; set; }

        public AppHubBoundedContextInstance(Func<IExternalEventPublisher, IAppBoundedContext> factory)
        {
            Factory = factory;
        }
    }

    public class AppHub : IExternalEventPublisher, IDisposable
    {
        public AppHub()
        {
            _boundedContexts = new Dictionary< Type, AppHubBoundedContextInstance >();
        }

        public void RegisterBoundedContext< TBoundedContext >(Func< IExternalEventPublisher, IAppBoundedContext > factory)
            where TBoundedContext : IAppBoundedContext
        {
            var boundedContextType = typeof(TBoundedContext);

            _boundedContexts.Add
                (
                    boundedContextType,
                    new AppHubBoundedContextInstance(factory)
                );
        }

        public TBoundedContext GetBoundedContext< TBoundedContext >() 
            where TBoundedContext : class, IAppBoundedContext
        {
            var boundedContextType = typeof(TBoundedContext);
            AppHubBoundedContextInstance item;

            if (!_boundedContexts.TryGetValue(boundedContextType, out item))
            {
                throw new InvalidOperationException("No such bounded context registered");
            }

            if (item.BoundedContext == null)
            {
                var boundedContextInstance = item.Factory(this);

                Debug.Assert((boundedContextInstance as TBoundedContext) != null);

                item.BoundedContext = boundedContextInstance;
            }

            var result = item.BoundedContext as TBoundedContext;

            return result;
        }

        public uint PublishEvent<TEvent>(IAppBoundedContext sourceBoundedContext, TEvent @event) where TEvent : IEvent
        {
            uint listenerCount = 0;

            foreach (var entry in _boundedContexts)
            {
                var boundedContext = entry.Value.BoundedContext;

                if (boundedContext != null && boundedContext != sourceBoundedContext)
                {
                    listenerCount += boundedContext.PublishEvent(@event);
                }
            }

            return listenerCount;
        }

        public void Dispose()
        {
            foreach (var entry in _boundedContexts)
            {
                if (entry.Value.BoundedContext != null)
                {
                    entry.Value.BoundedContext.Dispose();
                }
            }
        }

        private readonly Dictionary< Type, AppHubBoundedContextInstance > _boundedContexts;
    }
}
