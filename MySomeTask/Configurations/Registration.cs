namespace MySomeTask.Configurations
{
    public class Registration
    {
        /// <summary>
        /// Интервал в сек., через который разрешена регистрация с одного IP
        /// </summary>
        public int AllowedIntervalInSeconds { get; set; } = 5;
        
    }
}
