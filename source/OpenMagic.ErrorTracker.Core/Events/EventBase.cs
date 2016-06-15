using System;

namespace OpenMagic.ErrorTracker.Core.Events
{
    public abstract class EventBase : IEvent
    {
        protected EventBase()
        {
            EventId = Guid.NewGuid();
        }

        public Guid EventId { get; }
    }
}