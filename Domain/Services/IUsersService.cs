using System.Collections.Generic;
using System.Threading.Tasks;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services.Communication;

namespace meetapp_dotnet.Domain.Services
{
  public interface IUsersService
  {
    Task<IEnumerable<Users>> ListAsync();
    Task<UserResponse> SaveAsync(Users user);
    Task<UserResponse> UpdateAsync(int id, Users user);
    Task<UserResponse> DeleteAsync(int id);
    Task<Users> FindByEmailAsync(string email);
    Task<UserResponse> CreateUserAsync(Users user);

  }
}