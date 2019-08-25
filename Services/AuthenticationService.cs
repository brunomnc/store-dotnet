using meetapp_dotnet.Domain.Services;
using meetapp_dotnet.Domain.Security.Tokens;
using meetapp_dotnet.Domain.Security.Hashing;
using meetapp_dotnet.Domain.Services.Communication;
using System.Threading.Tasks;

namespace meetapp_dotnet.Services
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly IUsersService _userService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenHandler _tokenHandler;

    public AuthenticationService(IUsersService userService, IPasswordHasher passwordHasher, ITokenHandler tokenHandler)
    {
      _tokenHandler = tokenHandler;
      _passwordHasher = passwordHasher;
      _userService = userService;
    }

    public async Task<TokenResponse> CreateAccessTokenAsync(string email, string password)
    {
      var user = await _userService.FindByEmailAsync(email);

      if (user == null || !_passwordHasher.PasswordMatches(password, user.PasswordHash))
      {
        return new TokenResponse(false, "invalid password", null);
      }

      var token = _tokenHandler.CreateAccessToken(user);

      return new TokenResponse(true, null, token);

    }
  }
}