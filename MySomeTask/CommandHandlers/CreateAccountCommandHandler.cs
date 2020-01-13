using MySomeTask.Commands;
using MySomeTask.DataBase;
using MySomeTask.DomainEventHandlers;
using System.Threading.Tasks;

namespace MySomeTask.CommandHandlers
{
  public class CreateAccountCommandHandler : IAsyncCommandHandler<CreateAccount>
  {
    private readonly AccountContext _context;
    //private readonly StringValidator _stringValidator;
    //private readonly IOptions<Registration> _config;
    //private readonly IActivationCodeService _activationCodeService;
    //private readonly IDateTimeService _dateTimeService;
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    //public CreateAccountCommandHandler(AccountContext context,
    //    StringValidator stringValidator,
    //    IOptions<Registration> config,
    //    IActivationCodeService activationCodeService,
    //    IDateTimeService dateTimeService,
    //    IDomainEventDispatcher domainEventDispatcher)
    //{
    //  _context = context;
    //  _stringValidator = stringValidator;
    //  _config = config;
    //  _activationCodeService = activationCodeService;
    //  _dateTimeService = dateTimeService;
    //  _domainEventDispatcher = domainEventDispatcher;
    //}

    public async Task ExecuteAsync(CreateAccount cmd)
    {


      //var existsAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.MobilePhone == mobilePhone);
      //if (existsAccount != null)
      //  throw new CommandHandlerException($"Пользователь с номером телефона {cmd.MobilePhone} уже зарегистрирован в системе");

      //var email = cmd.Email;
      //if (!string.IsNullOrWhiteSpace(email))
      //  email = email.ToLowerInvariant();

      //existsAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
      //if (existsAccount != null)
      //  throw new CommandHandlerException($"Пользователь с {email} уже зарегистрирован в системе");

      //existsAccount = await _context.Accounts.Where(a => a.IP == cmd.IP)
      //    .OrderByDescending(a => a.CreatedAt)
      //    .FirstOrDefaultAsync();

      //var currentDateTime = _dateTimeService.GetCurrent();
      //var allowedInterval = _config.Value.AllowedInterval;
      //if (existsAccount != null && currentDateTime.Subtract(existsAccount.CreatedAt).Seconds < allowedInterval)
      //  throw new CommandHandlerException(403, $"С одного IP разрешено регистрироваться не более одного раза в {allowedInterval} сек.");


      //_stringValidator.NormalizeAndCheckStringConstraint("Email", ref email, true, StringValidator.StringFormat.Email);
      //_stringValidator.CheckStringConstraint("Name", cmd.Name, false, 100, 5);
      //_stringValidator.CheckStringConstraint("Password", cmd.Password, true, 50, 5);


      //if (_stringValidator.ErrorMessages.Any())
      //  throw new CommandHandlerException("Не верно заполнены поля регистрационной формы",
      //      _stringValidator.ErrorMessages);

      //var activationCode = _activationCodeService.GetNew();

      //currentDateTime = _dateTimeService.GetCurrent();
      //var account = new Account()
      //{
      //  Id = Guid.NewGuid(),
      //  CreatedAt = currentDateTime,
      //  MobilePhone = mobilePhone,
      //  Email = email,
      //  Name = cmd.Name,
      //  Password = cmd.Password.GetSha256Hash(),
      //  ActivationCode = activationCode,
      //  Roles = _config.Value.DefaultRoles,
      //  IP = cmd.IP,
      //  Mailing = true
      //};
      //_context.Accounts.Add(account);

      //await _context.SaveChangesAsync();

      //cmd.MobilePhone = mobilePhone;
      //cmd.Email = email;

      //_domainEventDispatcher.Raise(new CreatedAccountEvent(account));
      //_domainEventDispatcher.Raise(new CreatedActivationCodeEvent(activationCode, email));

    }
  }
}
