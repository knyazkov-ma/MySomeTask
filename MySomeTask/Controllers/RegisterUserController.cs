using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySomeTask.ApiModels;

namespace MySomeTask.Controllers
{
	[Route("api/v1/[controller]")]
	public class RegisterUserController : Controller
	{
		
    
    [HttpGet("emailvalidate")]
    public async Task<IActionResult> GetEmailValidate([FromQuery]string email)
    {
      if(email == "1")
        return Ok(null);

      var r = new
      {
        domain = new string[]
        {
          "Должен быть уникальным",
          "Не должен быть из стоплиста"
        },
        pattern = new string[]
        {
          "Должен быть вааалидным"
        }
      };

      return Ok(r);
    }

    [HttpGet("passwordvalidate")]
    public async Task<IActionResult> GetPasswordValidate([FromQuery]string password)
    {
      if (password == "1")
        return Ok(null);

      var r = new
      {
        domain = new string[]
        {
          "Должен быть клёвым",
          "Не должен быть не быть клёвым"
        },
        pattern = new string[]
        {
          "Должен быть вууулидным"
        }
      };

      return Ok(r);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]RegisterUserModel model)
    {
      int a = 1;
      return Created(string.Empty, null);
    }
  }
  
}
