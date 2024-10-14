
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Domain.Models;
using System.Text;

namespace SlimFinancial.Api.Registrars;

    public class JwtServiceRegistrar : IWebApplicationBuilderRegistrar
    {

        public void RegisterServices(WebApplicationBuilder builder)
        {
        builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
                {
                    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        RequireExpirationTime = false
                    };
             });
        }
            
    }

