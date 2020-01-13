using MySomeTask.Commands;
using System.Threading.Tasks;

namespace MySomeTask.CommandHandlers
{
  public class SendActivationCodeCommandHandler : IAsyncCommandHandler<SendActivationCode>
  {


    public async Task ExecuteAsync(SendActivationCode cmd)
    {


    }
  }
}
