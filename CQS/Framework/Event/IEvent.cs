using System;

namespace CQS.Framework.Event
{
    public interface IEvent
    {
        string Name { get; }
        DateTime Time { get; }
    }
}