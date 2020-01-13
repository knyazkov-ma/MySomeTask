using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySomeTask.ApiModels;
using MySomeTask.CommandHandlers;
using MySomeTask.Commands;
using MySomeTask.DataBase;
using MySomeTask.Validators;

namespace MySomeTask.Controllers
{
  [Route("api/v1/[controller]")]
	public class RegisterUserController : Controller
	{
    private readonly IAsyncCommandHandler<CreateAccount> _createAccountCommandHandler;
    private readonly AccountContext _context;

    public RegisterUserController(IAsyncCommandHandler<CreateAccount> createAccountCommandHandler,
      AccountContext context)
    {
      _createAccountCommandHandler = createAccountCommandHandler;
      _context = context;
    }

    [HttpGet("emailvalidate")]
    public async Task<IActionResult> GetEmailValidate([FromQuery]string email)
    {
      var validator = new MailValidator(_context);
      var result = await validator.ValidateAsync(email);

      if (result.IsValid)
        return Ok();

      var r = new
      {
        domain = result.Errors?.Select(e => e.ErrorMessage).ToArray()
      };

      return Ok(r);
    }

    [HttpGet("passwordvalidate")]
    public async Task<IActionResult> GetPasswordValidate([FromQuery]string password)
    {
      var validator = new PasswordValidator();
      var result = validator.Validate(password);

      if (result.IsValid)
        return Ok();

      var r = new
      {
        domain = result.Errors?.Select(e => e.ErrorMessage).ToArray()
      };

      return Ok(r);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]RegisterUserModel model)
    {
      await _createAccountCommandHandler.ExecuteAsync(new CreateAccount
      {
        Email = model.Email,
        Password = model.Password,
        Country = model.Country,
        Province = model.Province,
        IP = HttpContext.Connection.RemoteIpAddress != null ? HttpContext.Connection.RemoteIpAddress.ToString() : null
      });
      return Created(string.Empty, null);
    }
  }
  
}
