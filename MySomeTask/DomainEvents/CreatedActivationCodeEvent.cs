namespace MySomeTask.DomainEvents
{
    /// <summary>
    /// Событие создание кода активации
    /// </summary>
    public class CreatedActivationCodeEvent : IDomainEvent
    {
        public int ActivationCode { get; }        
        public string Email { get; }
        

        public CreatedActivationCodeEvent(int activationCode,
            string email)
        {
            ActivationCode = activationCode;            
            Email = email;            
        }
    }    
}
