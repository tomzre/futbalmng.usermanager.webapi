using System.Threading.Tasks;

namespace UserManager.Infrastructure.Services
{
    public interface IDataInitializer: IService
    {
         Task SeedAsync();
    }
}