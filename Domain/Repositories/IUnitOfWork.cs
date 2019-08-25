using System.Threading.Tasks;

namespace meetapp_dotnet.Domain.Repositories
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}