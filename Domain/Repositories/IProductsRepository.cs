using System.Collections.Generic;
using System.Threading.Tasks;
using meetapp_dotnet.Domain.Models;

namespace meetapp_dotnet.Domain.Repositories
{
  public interface IProductsRepository
  {
    Task<IEnumerable<Products>> ListAsync();
    Task AddAsync(Products product);
    Task<Products> FindByIdAsync(int id);
    void Update(Products product);
  }
}