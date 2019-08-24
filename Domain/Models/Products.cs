using System;
using System.Collections.Generic;

namespace meetapp_dotnet.Domain.Models
{
  public class Products
  {
    public int Id { get; set; }
    public int Code { get; set; }
    public float? Price { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
  }
}
