using Microsoft.EntityFrameworkCore;

public class ProductContext : DbContext
{
  public ProductContext(DbContextOptions<ProductContext> options) : base(options)
  { }

  public DbSet<meetapp_dotnet.Domain.Models.Products> Products { get; set; }
}