namespace meetapp_dotnet.Domain.Security.Tokens
{
  public class RefreshToken : JsonWebToken
  {
    public RefreshToken(string token, long expiration) : base(token, expiration)
    {
    }
  }
}