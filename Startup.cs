using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using msToken = Microsoft.IdentityModel.Tokens;

using meetapp_dotnet.Persistence.Contexts;
using meetapp_dotnet.Domain.Repositories;
using meetapp_dotnet.Domain.Services;
using meetapp_dotnet.Persistence.Repositories;
using meetapp_dotnet.Services;
using meetapp_dotnet.Domain.Security.Hashing;
using meetapp_dotnet.Domain.Security.Tokens;
using meetapp_dotnet.Security.Hashing;
using meetapp_dotnet.Security.Tokens;


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

      services.AddSingleton<IPasswordHasher, PasswordHasher>();
      services.AddSingleton<ITokenHandler, TokenHandler>();

      services.AddScoped<IAuthenticationService, AuthenticationService>();

      services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));

      var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

      var signingConfigurations = new SigningConfigurations();
      services.AddSingleton(signingConfigurations);

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(JwtBearerOptions =>
      {
        JwtBearerOptions.TokenValidationParameters = new msToken.TokenValidationParameters()
        {
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = tokenOptions.Issuer,
          ValidAudience = tokenOptions.Audience,
          IssuerSigningKey = signingConfigurations.Key,
          ClockSkew = TimeSpan.Zero
        };
      });

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
