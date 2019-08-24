using System.Collections.Generic;
using System.Threading.Tasks;
using meetapp_dotnet.Domain.Models;

namespace meetapp_dotnet.Domain.Services
{
  public interface IUsersService
  {
    Task<IEnumerable<Users>> ListAsync();
  }
}