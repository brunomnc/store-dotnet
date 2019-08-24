using meetapp_dotnet.Persistence.Contexts;

namespace meetapp_dotnet.Persistence.Repositories
{
  public abstract class BaseRepository
  {
    protected readonly meetappContext _context;

    public BaseRepository(meetappContext context)
    {
      _context = context;
    }
  }
}