using MySomeTask.DomainEvents;
using System.Collections.Generic;

namespace MySomeTask.DomainEventHandlers
{
    /// <summary>
    /// Фабрика обработчиков доменных событий
    /// </summary>
    public interface IDomainEventHandlerFactory
    {
        IEnumerable<IDomainEventHandler<TEvent>> Get<TEvent>() where TEvent : IDomainEvent;
        void Release(IDomainEventHandler handler);
    }
}
