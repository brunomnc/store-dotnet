using meetapp_dotnet.Domain.Models;

namespace meetapp_dotnet.Domain.Services.Communication
{
  public class ProductsResponse : BaseResponse
  {
    public Products Products { get; private set; }

    private ProductsResponse(bool success, string message, Products products) : base(success, message)
    {
      Products = products;
    }

    public ProductsResponse(Products products) : this(true, string.Empty, products) { }
    public ProductsResponse(string message) : this(true, message, null) { }
  }
}