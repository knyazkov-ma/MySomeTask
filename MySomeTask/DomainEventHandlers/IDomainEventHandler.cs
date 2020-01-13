using MySomeTask.DomainEvents;

namespace MySomeTask.DomainEventHandlers
{
    /// <summary>
    /// Обработчик доменного события - маркерный интерфейс для регистрации к контейнере
    /// </summary>
    public interface IDomainEventHandler
    {
    }

    /// <summary>
    /// Синхронный обработчик доменного события
    /// </summary>
    public interface IDomainEventHandler<TEvent> : IDomainEventHandler where TEvent : IDomainEvent
    {
        void Handle(TEvent e);
    }

    /// <summary>
    /// Асинхронный обработчик доменного события
    /// </summary>
    public interface IAsyncDomainEventHandler<TEvent> : IDomainEventHandler where TEvent : IDomainEvent
    {
        void HandleAsync(TEvent e);
    }
}
