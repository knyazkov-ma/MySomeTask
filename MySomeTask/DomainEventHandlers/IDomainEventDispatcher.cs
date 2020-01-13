using MySomeTask.DomainEvents;

namespace MySomeTask.DomainEventHandlers
{
    /// <summary>
    /// Диспетчер доменных событий
    /// </summary>
    public interface IDomainEventDispatcher
    {
        void Raise<TEvent>(TEvent e) where TEvent : IDomainEvent;
    }
}
