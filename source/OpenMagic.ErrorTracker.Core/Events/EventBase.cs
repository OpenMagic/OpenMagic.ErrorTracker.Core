using System;

namespace OpenMagic.ErrorTracker.Core.Events
{
    /// <summary>
    ///     Implements <see cref="IEvent" />.
    /// </summary>
    /// <seealso cref="OpenMagic.ErrorTracker.Core.Events.IEvent" />
    public abstract class EventBase : IEvent
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EventBase" /> class.
        /// </summary>
        protected EventBase()
            : this(Guid.NewGuid())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventBase" /> class.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        protected EventBase(Guid eventId)
        {
            EventId = eventId;
        }

        /// <summary>
        ///     Gets the event identifier.
        /// </summary>
        public Guid EventId { get; }
    }
}