using Microsoft.Extensions.Options;
using MySomeTask.Commands;
using MySomeTask.Commands.Validators;
using MySomeTask.Configurations;
using MySomeTask.DataBase;
using MySomeTask.DomainEventHandlers;
using MySomeTask.DomainEvents;
using MySomeTask.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MySomeTask.DataBase.Entities;
using MySomeTask.Loggers;

namespace MySomeTask.CommandHandlers
{
  public class CreateAccountCommandHandler : IAsyncCommandHandler<CreateAccount>
  {
    private readonly AccountContext _context;
    private readonly IOptions<Registration> _config;
    private readonly IPasswordService _passwordService;
    private readonly IDomainEventDispatcher _domainEventDispatcher;
    private readonly ILoggerService _loggerService;

    public CreateAccountCommandHandler(AccountContext context,
        IOptions<Registration> config,        
        IPasswordService passwordService,
        IDomainEventDispatcher domainEventDispatcher,
        ILoggerService loggerService)
    {
      _context = context;      
      _config = config;      
      _passwordService = passwordService;
      _domainEventDispatcher = domainEventDispatcher;
      _loggerService = loggerService;
    }

    public async Task ExecuteAsync(CreateAccount cmd)
    {

      var validator = new CreateAccountValidator(_context);
      var validationResult = validator.Validate(cmd);
      CommandHandlerException.Throw(validationResult);

      var existsAccount = await _context.Accounts.Where(a => a.IP == cmd.IP)
          .OrderByDescending(a => a.CreatedAt)
          .FirstOrDefaultAsync();

      var currentDateTime = DateTime.Now;
      var allowedInterval = _config.Value.AllowedIntervalInSeconds;
      if (existsAccount != null && currentDateTime.Subtract(existsAccount.CreatedAt).Seconds < allowedInterval)
      {
        var ex = new CommandHandlerException(403, $"С одного IP разрешено регистрироваться не более одного раза в {allowedInterval} сек.");
        _loggerService.LogError(ex, ex.Message);
        throw ex;
      }

      var account = new Account(currentDateTime,
        cmd.IP,
        cmd.Email.ToLower(),
        _passwordService.GetSha256Hash(cmd.Password),
        cmd.Country,
        cmd.Province);

      _context.Accounts.Add(account);

      await _context.SaveChangesAsync();
      
      _domainEventDispatcher.Raise(new CreatedAccountEvent(account));     

    }
  }
}
