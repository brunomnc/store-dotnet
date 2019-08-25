using System.Threading.Tasks;
using meetapp_dotnet.Domain.Services.Communication;

namespace meetapp_dotnet.Domain.Services
{
  public interface IAuthenticationService
  {
    Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
  }
}