using Microsoft.EntityFrameworkCore;

public class UsersContext : DbContext
{
  public UsersContext(DbContextOptions<UsersContext> options)
      : base(options)
  {
  }

  public DbSet<meetapp_dotnet.Domain.Models.Users> Users { get; set; }
}
