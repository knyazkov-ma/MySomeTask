using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using MySomeTask.Dto;
using System.Collections.Generic;

namespace MySomeTask.Cache
{
  public class CountryCache : BaseCache<IEnumerable<CountryDto>>
  {
    public CountryCache(IDistributedCache cache, IOptions<Configurations.Cache> config)
      : base(cache,
                 config.Value.Locations.KeyPrefix,
                 config.Value.Locations.DurationInMinutes)
    {

    }

  }
}
