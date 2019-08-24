using System;
using System.Collections.Generic;

namespace meetapp_dotnet.Domain.Models
{
  public class Users
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string PasswordHash { get; set; }
    public bool? Provider { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}
