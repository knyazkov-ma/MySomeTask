using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace MySomeTask.Cache
{
  public class ProvinceCache : BaseCache<IEnumerable<string>>
  {
    public ProvinceCache(IDistributedCache cache, IOptions<Configurations.Cache> config)
      : base(cache,
                 config.Value.Locations.KeyPrefix,
                 config.Value.Locations.DurationInMinutes)
    {

    }

  }
}
