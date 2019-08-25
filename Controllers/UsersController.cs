using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services;
using meetapp_dotnet.Resources;
using AutoMapper;
using meetapp_dotnet.Extensions;


namespace meetapp_dotnet.Controllers
{
  [Route("/api/[controller]")]
  public class UsersController : Controller
  {
    private readonly IUsersService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUsersService categoryService, IMapper mapper)
    {
      _userService = categoryService;
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
  }
}
