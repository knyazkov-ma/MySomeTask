using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySomeTask.Dto;
using MySomeTask.Queries;
using MySomeTask.QueryHandlers;

namespace MySomeTask.Controllers
{
  [Route("api/v1/[controller]")]
	public class LocationController : Controller
	{
    private readonly IAsyncQueryHandler<GetCountries, IEnumerable<CountryDto>> _getCountriesQueryHandler;
    private readonly IAsyncQueryHandler<GetProvincies, IEnumerable<string>> _getProvinciesQueryHandler;

    public LocationController(IAsyncQueryHandler<GetCountries, IEnumerable<CountryDto>> getCountriesQueryHandler,
      IAsyncQueryHandler<GetProvincies, IEnumerable<string>> getProvinciesQueryHandler)
    {
      _getCountriesQueryHandler = getCountriesQueryHandler;
      _getProvinciesQueryHandler = getProvinciesQueryHandler;
    }

    [HttpGet("countries")]
    public async Task<IEnumerable<CountryDto>> GetCountries()
    {
      return await _getCountriesQueryHandler.ExecuteAsync(new GetCountries());
    }

    [HttpGet("provincies/{code}")]    
    public async Task<IEnumerable<string>> GetProvincies([FromRoute]string code)
    {
      return await _getProvinciesQueryHandler.ExecuteAsync(new GetProvincies { CountryCode = code });
    }
    
  }
  
}
