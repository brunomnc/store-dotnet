using meetapp_dotnet.Domain.Security.Tokens;

namespace meetapp_dotnet.Domain.Services.Communication
{
  public class TokenResponse : BaseResponse
  {
    public AccessToken Token { get; set; }

    public TokenResponse(bool success, string message, AccessToken token) : base(success, message)
    {
      Token = token;
    }
  }
}