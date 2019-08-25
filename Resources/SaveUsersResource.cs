using System.ComponentModel.DataAnnotations;

namespace meetapp_dotnet.Resources
{
  public class SaveUsersResource
  {
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    [Required]
    [MaxLength(4)]
    public string PasswordHash { get; set; }
  }
}