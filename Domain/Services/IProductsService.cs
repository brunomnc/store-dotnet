using System.Collections.Generic;
using System.Threading.Tasks;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services.Communication;

namespace meetapp_dotnet.Domain.Services
{
  public interface IProductsService
  {
    Task<IEnumerable<Products>> ListAsync();
    Task<ProductsResponse> AddAsync(Products product);
    Task<ProductsResponse> UpdateAsync(int id, Products product);
  }
}