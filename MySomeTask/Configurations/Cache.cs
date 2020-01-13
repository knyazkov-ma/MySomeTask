namespace MySomeTask.Configurations
{
    public class CacheItem
    {
        public string KeyPrefix { get; set; }
        public int DurationInMinutes { get; set; }
    }

    public class Cache
    {
        public CacheItem Locations { get; set; }        
    }
}
