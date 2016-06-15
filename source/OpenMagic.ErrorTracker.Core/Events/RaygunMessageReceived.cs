using Mindscape.Raygun4Net.Messages;

namespace OpenMagic.ErrorTracker.Core.Events
{
    public class RaygunMessageReceived : EventBase
    {
        public RaygunMessageReceived(string apiKey, RaygunMessage raygunMessage)
        {
            ApiKey = apiKey;
            Message = raygunMessage;
        }

        public string ApiKey { get; }
        public RaygunMessage Message { get; }
    }
}