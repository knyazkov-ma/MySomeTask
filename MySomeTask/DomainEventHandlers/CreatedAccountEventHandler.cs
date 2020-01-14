using MySomeTask.DomainEvents;

namespace MySomeTask.DomainEventHandlers
{
  /// <summary>
  /// Обработчик доменного события CreatedAccountEvent
  /// </summary>
  public class CreatedAccountEventHandler : IDomainEventHandler<CreatedAccountEvent>
  {
    public void Handle(CreatedAccountEvent e)
    { }
  }

}
