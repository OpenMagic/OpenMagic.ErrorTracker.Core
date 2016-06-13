using System;

namespace OpenMagic.ErrorTracker.Core.Events
{
    public interface IEvent
    {
        Guid EventId { get; }
    }
}