using System.ComponentModel.DataAnnotations;

namespace meetapp_dotnet.Controllers.Resources
{
  public class UserCredentialResource
  {
    [Required]
    [DataType(DataType.EmailAddress)]
    [StringLength(255)]
    public string Email { get; set; }

    [Required]
    [StringLength(4)]
    public string PasswordHash { get; set; }
  }
}