using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using meetapp_dotnet.Persistence.Contexts;
using meetapp_dotnet.Domain.Repositories;
using meetapp_dotnet.Domain.Services;
using meetapp_dotnet.Persistence.Repositories;
using meetapp_dotnet.Services;

namespace meetapp_dotnet
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddEntityFrameworkNpgsql().AddDbContext<meetappContext>(opt =>
        opt.UseNpgsql(Configuration.GetConnectionString("MeetAppConnection")));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddScoped<IUsersService, UsersService>();
      services.AddScoped<IUsersRepository, UsersRepository>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddAutoMapper(typeof(Startup));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseMvc();
      app.UseCors("AllowSpecificOrigin");
    }
  }
}
