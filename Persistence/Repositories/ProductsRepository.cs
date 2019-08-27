using meetapp_dotnet.Domain.Repositories;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace meetapp_dotnet.Persistence.Repositories
{
  public class ProductsRepository : BaseRepository, IProductsRepository
  {
    public ProductsRepository(meetappContext context) : base(context) { }

    public async Task<IEnumerable<Products>> ListAsync()
    {
      return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Products products)
    {
      await _context.Products.AddAsync(products);
    }

    public async Task<Products> FindByIdAsync(int id)
    {
      return await _context.Products.FindAsync(id);
    }

    public void Update(Products products)
    {
      _context.Products.Update(products);
    }
  }
}