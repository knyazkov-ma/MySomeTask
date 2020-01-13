namespace MySomeTask.Configurations
{
    public class Activation
    {
        /// <summary>
        /// Интервал в сек., в течение которого требуется ввести код активации
        /// </summary>
        public int AllowedIntervalInSeconds { get; set; } = 120;
            
    }
}
