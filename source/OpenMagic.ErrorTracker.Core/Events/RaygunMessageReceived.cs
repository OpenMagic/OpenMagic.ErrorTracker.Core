using System;
using Mindscape.Raygun4Net.Messages;

namespace OpenMagic.ErrorTracker.Core.Events
{
    public class RaygunMessageReceived : IEvent
    {
        public RaygunMessageReceived(string apiKey, RaygunMessage raygunMessage)
        {
            EventId = Guid.NewGuid();
            ApiKey = apiKey;
            Message = raygunMessage;
        }

        public Guid EventId { get; }
        public string ApiKey { get; }
        public RaygunMessage Message { get; }
    }
}