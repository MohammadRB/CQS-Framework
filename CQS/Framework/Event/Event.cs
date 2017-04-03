using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Framework.Event
{
    public class Event : IEvent
    {
        public string Name { get { return _name; } }
        public DateTime Time { get { return _time; } }

        public Event()
        {
            _name = GetType().Name;
            _time = new DateTime();
        }

        public Event(string name)
        {
            _name = name;
            _time = new DateTime();
        }

        private readonly string _name;
        private readonly DateTime _time;
    }
}
