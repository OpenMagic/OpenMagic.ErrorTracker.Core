using System;
using System.Threading.Tasks;
using OpenMagic.ErrorTracker.Core.Events;

namespace OpenMagic.ErrorTracker.Core.Repositories
{
    /// <summary>
    ///     Store and read events for an aggregate.
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        ///     Add an <see cref="IEvent">event</see> for the specified <typeparamref name="TAggregate">aggregate</typeparamref>.
        /// </summary>
        /// <typeparam name="TAggregate">The type of the aggregate.</typeparam>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <param name="event">The event to store.</param>
        Task AddAsync<TAggregate>(Guid aggregateId, IEvent @event);

        /// <summary>
        ///     Add an <see cref="IEvent">event</see> for the specified <paramref name="aggregateType">aggregate</paramref>.
        /// </summary>
        /// <param name="aggregateType">The type of the aggregate.</param>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <param name="event">The event to store.</param>
        Task AddAsync(Type aggregateType, Guid aggregateId, IEvent @event);
    }
}