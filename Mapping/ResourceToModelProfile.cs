using AutoMapper;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Resources;

namespace meetapp_dotnet.Mapping
{
  public class ResourceToModelProfile : Profile
  {
    public ResourceToModelProfile()
    {
      CreateMap<SaveUsersResource, Users>();
    }
  }
}