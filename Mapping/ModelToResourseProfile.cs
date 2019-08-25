using AutoMapper;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Resources;

namespace meetapp_dotnet.Mapping
{
  public class ModelToResourceProfile : Profile
  {
    public ModelToResourceProfile()
    {
      CreateMap<Users, UsersResource>();
    }
  }
}