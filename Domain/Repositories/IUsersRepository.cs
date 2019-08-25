using System.Collections.Generic;
using System.Threading.Tasks;
using meetapp_dotnet.Domain.Models;

namespace meetapp_dotnet.Domain.Repositories
{
  public interface IUsersRepository
  {
    Task<IEnumerable<Users>> ListAsync();
    Task AddAsync(Users user);
    Task<Users> FindByIdAsync(int id);
    void Update(Users user);
    void Remove(Users user);
  }
}