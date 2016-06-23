using System;

namespace OpenMagic.ErrorTracker.Core.Events
{
    /// <summary>
    ///     Represents an aggregate event
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        ///     Gets the event identifier.
        /// </summary>
        Guid EventId { get; }
    }
}