using System;

namespace CQS.Framework.Event
{
    public class Event : IEvent
    {
        public string Name { get; }
        public DateTime Time { get; }

        public Event()
        {
            Name = GetType().Name;
            Time = new DateTime();
        }

        public Event(string name)
        {
            Name = name;
            Time = new DateTime();
        }
    }
}