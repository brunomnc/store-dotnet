using System.Collections.Generic;
using System.Threading.Tasks;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services;
using meetapp_dotnet.Domain.Repositories;

namespace meetapp_dotnet.Services
{
  public class UsersService : IUsersService
  {
    private readonly IUsersRepository _categoryRepository;

    public UsersService(IUsersRepository categoryRepository)
    {
      this._categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Users>> ListAsync()
    {
      return await _categoryRepository.ListAsync();
    }
  }
}