namespace MySomeTask.Commands
{
    /// <summary>
    /// Отправка кода активации
    /// </summary>
    public class SendActivationCode : Command
    {
        public string Email { get; set; }
        public int ActivationCode { get; set; }
    }
}
