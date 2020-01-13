using MySomeTask.Commands;
using System.Threading.Tasks;

namespace MySomeTask.CommandHandlers
{
    public interface ICommandHandler
    {        
    }

    public interface IAsyncCommandHandler<TCommand>: ICommandHandler
        where TCommand : Command
    {
        Task ExecuteAsync(TCommand cmd);
    }    
}
