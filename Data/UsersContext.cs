using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using meetapp_dotnet.Domain.Models;

public class UsersContext : DbContext
{
  public UsersContext(DbContextOptions<UsersContext> options)
      : base(options)
  {
  }

  public DbSet<meetapp_dotnet.Domain.Models.Users> Users { get; set; }
}
