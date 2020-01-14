using MySomeTask.Queries;
using MySomeTask.DataBase;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using MySomeTask.Cache;
using System;
using MySomeTask.Loggers;

namespace MySomeTask.QueryHandlers
{
  public class GetProvinciesQueryHandler :
      IAsyncQueryHandler<GetProvincies, IEnumerable<string>>
  {
    private readonly AccountContext _context;
    private readonly ProvinceCache _cache;
    private readonly ILoggerService _loggerService;

    public GetProvinciesQueryHandler(AccountContext context,
      ProvinceCache cache,
      ILoggerService loggerService)
    {
      _context = context;
      _cache = cache;
      _loggerService = loggerService;
    }

    public async Task<IEnumerable<string>> ExecuteAsync(GetProvincies query)
    {     

      try
      {
        var items = await _cache.AddOrGetExistingAsync($"Provincies-{query.CountryCode}",
            async () =>
            {
              return await _context.Locations
                .Where(l => l.CountryCode == query.CountryCode)
                .Select(l => l.ProvinceName)
                .Distinct()
                .OrderBy(l => l)
                .ToListAsync();
            });

        return items;
      }
      catch (Exception ex)
      {
        _loggerService.LogError(ex, ex.Message);
        return null;
      }
    }
  }
}
