using MySomeTask.DomainEvents;

namespace MySomeTask.DomainEventHandlers
{
    public class DefaultDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IDomainEventHandlerFactory _handlerFactory;

        public DefaultDomainEventDispatcher(IDomainEventHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        public void Raise<TEvent>(TEvent e) where TEvent : IDomainEvent
        {
            foreach (var handler in _handlerFactory.Get<TEvent>())
            {
                handler.Handle(e);
                _handlerFactory.Release(handler);
            }
        }
    }
}
