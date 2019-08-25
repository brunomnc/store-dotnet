using System.Collections.Generic;
using System.Threading.Tasks;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services.Communication;

namespace meetapp_dotnet.Domain.Services
{
  public interface IUsersService
  {
    Task<IEnumerable<Users>> ListAsync();
    Task<SaveUserResponse> SaveAsync(Users user);
  }
}