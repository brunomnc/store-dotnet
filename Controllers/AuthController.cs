using meetapp_dotnet.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using meetapp_dotnet.Controllers.Resources;
using System.Threading.Tasks;
using meetapp_dotnet.Domain.Security.Tokens;

namespace meetapp_dotnet.Controllers
{
  public class AuthController : Controller
  {
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AuthController(IAuthenticationService authenticationService, IMapper mapper)
    {
      _authenticationService = authenticationService;
      _mapper = mapper;
    }

    [Route("/api/login")]
    [HttpPost]
    public async Task<IActionResult> LoginAsync([FromBody] UserCredentialResource userCredential)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("teste");
      }

      var response = await _authenticationService.CreateAccessTokenAsync(userCredential.Email, userCredential.PasswordHash);

      if (!response.Success)
      {
        return BadRequest("teste2");
      }

      var accessTokenResource = _mapper.Map<AccessToken, AccessTokenResouce>(response.Token);
      return Ok(accessTokenResource);
    }

  }

}