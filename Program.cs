using System;
using System.Collections.Generic;
using meetapp_dotnet.Persistence.Contexts;
using meetapp_dotnet.Domain.Security.Hashing;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace meetapp_dotnet
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = BuildWebHost(args);

      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        var context = services.GetService<meetappContext>();
        var passwordHasher = services.GetService<IPasswordHasher>();
      }

      host.Run();
      //   CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    public static IWebHost BuildWebHost(string[] args) =>
            /*
             * The call to ".UseIISIntegration" is necessary to fix issue while running the API from ISS. See the following links for reference:
             * - https://github.com/aspnet/IISIntegration/issues/242
             * - https://stackoverflow.com/questions/50112665/newly-created-net-core-gives-http-400-using-windows-authentication
            */

            WebHost.CreateDefaultBuilder(args)
                   .UseIISIntegration()
                   .UseStartup<Startup>()
                   .Build();
  }
}
