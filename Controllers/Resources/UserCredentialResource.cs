using System.ComponentModel.DataAnnotations;

namespace meetapp_dotnet.Controllers.Resources
{
  public class UserCredentialResource
  {
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    [StringLength(255)]
    public string Email { get; set; }

    [Required]
    [StringLength(4)]
    public string PasswordHash { get; set; }
  }
}