using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services;
using meetapp_dotnet.Controllers.Resources;
using AutoMapper;
using meetapp_dotnet.Extensions;


namespace meetapp_dotnet.Controllers
{
  [Route("/api/[controller]")]
  public class UsersController : Controller
  {
    private readonly IUsersService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUsersService userService, IMapper mapper)
    {
      _userService = userService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UsersResource>> GetAllAsync()
    {
      var users = await _userService.ListAsync();
      var resources = _mapper.Map<IEnumerable<Users>, IEnumerable<UsersResource>>(users);
      return resources;
    }

    [HttpPost]
    public async Task<ActionResult<Users>> PostAsync([FromBody] SaveUsersResource resource)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState.GetErrorMessages());
      }

      var user = _mapper.Map<SaveUsersResource, Users>(resource);

      var result = await _userService.SaveAsync(user);

      if (!result.Success)
      {
        return BadRequest(result.Message);
      }

      var userResource = _mapper.Map<Users, UsersResource>(result.User);
      return Ok(userResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUsersResource resource)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var user = _mapper.Map<SaveUsersResource, Users>(resource);
      var result = await _userService.UpdateAsync(id, user);

      if (!result.Success)
      {
        return BadRequest();
      }

      var userResource = _mapper.Map<Users, UsersResource>(result.User);
      return Ok(userResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
      var result = await _userService.DeleteAsync(id);

      if (!result.Success)
      {
        return BadRequest();
      }

      var userResource = _mapper.Map<Users, UsersResource>(result.User);
      return Ok(userResource);
    }

    [HttpPost("{new}")]
    public async Task<IActionResult> CreateUserAsync([FromBody]UserCredentialResource userCredentials)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var user = _mapper.Map<UserCredentialResource, Users>(userCredentials);

      var response = await _userService.CreateUserAsync(user);

      if (!response.Success)
      {
        return BadRequest(response.Message);
      }

      var userResource = _mapper.Map<Users, UsersResource>(response.User);

      return Ok(userResource);
    }
  }
}
