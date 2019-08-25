using System.ComponentModel.DataAnnotations;

namespace meetapp_dotnet.Controllers.Resources
{
  public class SaveUsersResource
  {
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public int Age { get; set; }
    public string Email { get; set; }
    [Required]
    [MaxLength(4)]
    public string PasswordHash { get; set; }
  }
}