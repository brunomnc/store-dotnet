using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services;
using meetapp_dotnet.Domain.Repositories;
using meetapp_dotnet.Domain.Services.Communication;

namespace meetapp_dotnet.Services
{
  public class ProductsService : IProductsService
  {
    private readonly IProductsRepository _productsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductsService(IProductsRepository productsRepository, IUnitOfWork unitOfWork)
    {
      _productsRepository = productsRepository;
      _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Products>> ListAsync()
    {
      return await _productsRepository.ListAsync();
    }

    public async Task<ProductsResponse> AddAsync(Products products)
    {
      try
      {
        await _productsRepository.AddAsync(products);
        await _unitOfWork.CompleteAsync();

        return new ProductsResponse(products);
      }
      catch (Exception e)
      {
        return new ProductsResponse($"error: {e.Message}");
      }
    }

    public async Task<ProductsResponse> UpdateAsync(int id, Products products)
    {
      var productExists = await _productsRepository.FindByIdAsync(id);
      if (productExists == null)
      {
        return new ProductsResponse("product not found");
      }
      productExists.Name = products.Name;

      try
      {
        _productsRepository.Update(productExists);
        await _unitOfWork.CompleteAsync();

        return new ProductsResponse(productExists);
      }
      catch (Exception e)
      {
        return new ProductsResponse($"error: {e.Message}");
      }
    }
  }
}