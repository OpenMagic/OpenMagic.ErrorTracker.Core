using Mindscape.Raygun4Net.Messages;

namespace OpenMagic.ErrorTracker.Core.Events
{
    public class RaygunMessageReceived : IEvent
    {
        public RaygunMessageReceived(string apiKey, RaygunMessage raygunMessage)
        {
            ApiKey = apiKey;
            Message = raygunMessage;
        }

        public string ApiKey { get; private set; }
        public RaygunMessage Message { get; private set; }
    }
}