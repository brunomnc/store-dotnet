using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services;
using meetapp_dotnet.Controllers.Resources;
using AutoMapper;
using meetapp_dotnet.Extensions;


namespace meetapp_dotnet.Controllers
{
  [Route("/api/[controller]")]
  public class ProductsController : Controller
  {
    private readonly IProductsService _productsService;
    private readonly IMapper _mapper;

    public ProductsController(IProductsService productsService, IMapper mapper)
    {
      _productsService = productsService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductsResource>> GetAllAsync()
    {
      var products = await _productsService.ListAsync();
      var resources = _mapper.Map<IEnumerable<Products>, IEnumerable<ProductsResource>>(products);
      return resources;
    }
  }
}