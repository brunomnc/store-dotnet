using System;
using meetapp_dotnet.Domain.Security.Tokens;
using System.IdentityModel.Tokens.Jwt;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Security.Hashing;
using System.Security.Claims;
using System.Collections.Generic;

namespace meetapp_dotnet.Security.Tokens
{
  public class TokenHandler : ITokenHandler
  {
    private readonly IPasswordHasher _passwordHasher;
    private readonly TokenOptions _tokenOptions;
    private readonly SigningConfigurations _signingConfigurations;
    public AccessToken CreateAccessToken(Users user)
    {
      var refreshToken = BuildRefreshToken(user);
      var accessToken = BuildAccessToken(user, refreshToken);

      return accessToken;
    }

    private RefreshToken BuildRefreshToken(Users user)
    {
      var refreshToken = new RefreshToken
      (
        token: _passwordHasher.HashPassword(Guid.NewGuid().ToString()),
        expiration: DateTime.UtcNow.AddSeconds(_tokenOptions.RefreshTokenExpiration).Ticks
      );
      return refreshToken;
    }

    private AccessToken BuildAccessToken(Users user, RefreshToken refreshToken)
    {
      var accessTokenExpiration = DateTime.UtcNow.AddSeconds(_tokenOptions.AccessTokenExpiration);

      var securityToken = new JwtSecurityToken(
        issuer: _tokenOptions.Issuer,
        audience: _tokenOptions.Audience,
        claims: GetClaims(user),
        expires: accessTokenExpiration,
        notBefore: DateTime.UtcNow,
        signingCredentials: _signingConfigurations.SigningCredentials
      );
      var handler = new JwtSecurityTokenHandler();
      var accessToken = handler.WriteToken(securityToken);

      return new AccessToken(accessToken, accessTokenExpiration.Ticks, refreshToken);

    }

    private IEnumerable<Claim> GetClaims(Users user)
    {
      var claims = new List<Claim>
      {
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Sub, user.Email)
      };

      return claims;
    }
  }
}