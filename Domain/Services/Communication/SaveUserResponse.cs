using meetapp_dotnet.Domain.Models;

namespace meetapp_dotnet.Domain.Services.Communication
{
  public class SaveUserResponse : BaseResponse
  {
    public Users User { get; private set; }

    private SaveUserResponse(bool success, string message, Users user) : base(success, message)
    {
      User = user;
    }

    public SaveUserResponse(Users user) : this(true, string.Empty, user)
    { }

    public SaveUserResponse(string message) : this(false, message, null)
    { }



  }
}