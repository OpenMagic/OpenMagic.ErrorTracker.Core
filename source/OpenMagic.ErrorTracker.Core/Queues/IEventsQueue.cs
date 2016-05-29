using System.Threading.Tasks;
using OpenMagic.ErrorTracker.Core.Events;

namespace OpenMagic.ErrorTracker.Core.Queues
{
    public interface IEventsQueue
    {
        Task AddAsync(IEvent @event);
    }
}