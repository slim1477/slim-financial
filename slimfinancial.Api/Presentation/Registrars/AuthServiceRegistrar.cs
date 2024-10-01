
using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Domain.Models.Entity;

namespace SlimFinancial.Api.Registrars;

    public class AuthServiceRegistrar : IWebApplicationBuilderRegistrar
    {
    
        public void RegisterServices(WebApplicationBuilder builder)
        {
        builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("key:JwtConfig"));
        }
    }

