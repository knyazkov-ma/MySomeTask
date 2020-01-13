using System;
using System.Collections.Generic;
using MySomeTask.DomainEvents;
using Microsoft.Extensions.DependencyInjection;


namespace MySomeTask.DomainEventHandlers
{
    public class ContainerDomainEventHandlerFactory : IDomainEventHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ContainerDomainEventHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<IDomainEventHandler<TEvent>> Get<TEvent>() where TEvent : IDomainEvent
        {
            return _serviceProvider.GetServices<IDomainEventHandler<TEvent>>();
        }

        public void Release(IDomainEventHandler handler)
        {
        }
    }
}
