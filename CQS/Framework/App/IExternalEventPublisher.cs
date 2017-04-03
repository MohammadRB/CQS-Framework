using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Event;

namespace CQS.Framework.App
{
    public interface IExternalEventPublisher
    {
        uint PublishEvent< TEvent >(IAppBoundedContext sourceBoundedContext, TEvent @event) where TEvent : IEvent;
    }
}
