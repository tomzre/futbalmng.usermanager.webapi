using System.Threading.Tasks;

namespace UserManager.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
         Task HandleAsync(T command);
    }
}