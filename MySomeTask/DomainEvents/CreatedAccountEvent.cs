using MySomeTask.DataBase.Entities;

namespace MySomeTask.DomainEvents
{
    /// <summary>
    /// Событие создание учетной записи
    /// </summary>
    public class CreatedAccountEvent : IDomainEvent
    {
        public Account Account { get; }        
        public CreatedAccountEvent(Account account)
        {
            Account = account;            
        }
    }    
}
