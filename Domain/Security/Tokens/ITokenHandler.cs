using meetapp_dotnet.Domain.Models;

namespace meetapp_dotnet.Domain.Security.Tokens
{
  public interface ITokenHandler
  {
    AccessToken CreateAccessToken(Users user);
  }
}