using MySomeTask.Dto;
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
  public class GetCountriesQueryHandler :
      IAsyncQueryHandler<GetCountries, IEnumerable<CountryDto>>
  {
    private readonly AccountContext _context;
    private readonly CountryCache _cache;

    public GetCountriesQueryHandler(AccountContext context,
      CountryCache cache)
    {
      _context = context;
      _cache = cache;
    }

    public async Task<IEnumerable<CountryDto>> ExecuteAsync(GetCountries query)
    {

      try
      {
        var items = await _cache.AddOrGetExistingAsync("Countries",
            async () =>
            {
              var r = await _context.Locations
                .Select(l => new CountryDto { Code = l.CountryCode, Name = l.CountryName })
                .Distinct()
                .OrderBy(l => l.Name)
                .ToListAsync();

              return r;
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
