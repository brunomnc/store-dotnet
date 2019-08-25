using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Repositories;
using meetapp_dotnet.Persistence.Contexts;

namespace meetapp_dotnet.Persistence.Repositories
{
  public class UsersRepository : BaseRepository, IUsersRepository
  {
    public UsersRepository(meetappContext context) : base(context)
    { }

    public async Task<IEnumerable<Users>> ListAsync()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(Users user)
    {
      await _context.Users.AddAsync(user);
    }
  }
}