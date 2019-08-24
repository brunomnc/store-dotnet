using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Domain.Services;


namespace meetapp_dotnet.Controllers
{
  [Route("/api/[controller]")]
  public class UsersController : Controller
  {
    private readonly IUsersService _userService;

    public UsersController(IUsersService categoryService)
    {
      _userService = categoryService;
    }

    [HttpGet]
    public async Task<IEnumerable<Users>> GetAllAsync()
    {
      var users = await _userService.ListAsync();
      return users;
    }
  }
}
