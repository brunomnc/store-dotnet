using AutoMapper;
using meetapp_dotnet.Domain.Models;
using meetapp_dotnet.Controllers.Resources;
using meetapp_dotnet.Domain.Security.Tokens;

namespace meetapp_dotnet.Mapping
{
  public class ModelToResourceProfile : Profile
  {
    public ModelToResourceProfile()
    {
      CreateMap<Users, UsersResource>();
      CreateMap<Products, ProductsResource>();

      CreateMap<AccessToken, AccessTokenResouce>()
      .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token));
    }
  }
}