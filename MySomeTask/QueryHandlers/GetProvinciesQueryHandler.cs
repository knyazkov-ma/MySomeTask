using MySomeTask.Queries;
using MySomeTask.DataBase;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using MySomeTask.Cache;
using System;
using Serilog;

namespace MySomeTask.QueryHandlers
{
  public class GetProvinciesQueryHandler :
      IAsyncQueryHandler<GetProvincies, IEnumerable<string>>
  {
    private readonly AccountContext _context;
    private readonly ProvinceCache _cache;
    public GetProvinciesQueryHandler(AccountContext context,
      ProvinceCache cache)
    {
      _context = context;
      _cache = cache;
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
        Log.Error(ex, ex.Message);
        return null;
      }
    }
  }
}
