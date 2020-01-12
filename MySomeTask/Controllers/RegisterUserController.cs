using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MySomeTask.Controllers
{
	[Route("api/v1/[controller]")]
	public class RegisterUserController : Controller
	{
		
    [HttpGet("countries")]
    public IEnumerable<dynamic> GetCountries()
    {
      return Enumerable.Range(1, 5).Select(index =>
        new { code = $"code{index}", name = $"Country {index}" }
      );
    }

    [HttpGet("provincies/{code}")]    
    public IEnumerable<string> GetProvincies([FromRoute]string code)
    {
      return Enumerable.Range(1, 5).Select(index => $"{code} - Province {index}");
    }
  }
}
