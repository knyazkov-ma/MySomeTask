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

namespace MySomeTask.CommandHandlers
{
  public class CreateAccountCommandHandler : IAsyncCommandHandler<CreateAccount>
  {
    private readonly AccountContext _context;
    private readonly IOptions<Registration> _config;
    private readonly IPasswordService _passwordService;
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    public CreateAccountCommandHandler(AccountContext context,
        IOptions<Registration> config,        
        IPasswordService passwordService,
        IDomainEventDispatcher domainEventDispatcher)
    {
      _context = context;      
      _config = config;      
      _passwordService = passwordService;
      _domainEventDispatcher = domainEventDispatcher;
    }

    public async Task ExecuteAsync(CreateAccount cmd)
    {

      var validator = new CreateAccountValidator(_context);
      validator.ValidateAndThrow(cmd);
      
      var existsAccount = await _context.Accounts.Where(a => a.IP == cmd.IP)
          .OrderByDescending(a => a.CreatedAt)
          .FirstOrDefaultAsync();

      var currentDateTime = DateTime.Now;
      var allowedInterval = _config.Value.AllowedIntervalInSeconds;
      if (existsAccount != null && currentDateTime.Subtract(existsAccount.CreatedAt).Seconds < allowedInterval)
        throw new CommandHandlerException(403, $"С одного IP разрешено регистрироваться не более одного раза в {allowedInterval} сек.");

      var account = new Account()
      {
        Id = Guid.NewGuid(),
        CreatedAt = currentDateTime,
        Email = cmd.Email.ToLower(),
        Password = _passwordService.GetSha256Hash(cmd.Password),
        IP = cmd.IP,
        Country = cmd.Country,
        Province = cmd.Province        
      };
      _context.Accounts.Add(account);

      await _context.SaveChangesAsync();
      
      _domainEventDispatcher.Raise(new CreatedAccountEvent(account));     

    }
  }
}
