using meetapp_dotnet.Domain.Models;

namespace meetapp_dotnet.Domain.Services.Communication
{
  public class UserResponse : BaseResponse
  {
    public Users User { get; private set; }

    private UserResponse(bool success, string message, Users user) : base(success, message)
    {
      User = user;
    }

    public UserResponse(Users user) : this(true, string.Empty, user)
    { }

    public UserResponse(string message) : this(false, message, null)
    { }



  }
}