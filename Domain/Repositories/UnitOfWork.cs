using System.Threading.Tasks;
using meetapp_dotnet.Domain.Repositories;
using meetapp_dotnet.Persistence.Contexts;

namespace meetapp_dotnet.Persistence.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly meetappContext _context;

    public UnitOfWork(meetappContext context)
    {
      _context = context;
    }

    public async Task CompleteAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}