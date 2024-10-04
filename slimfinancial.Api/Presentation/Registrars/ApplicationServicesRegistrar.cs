using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Application;
using SlimFinancial.Infrastructure.Services;

namespace SlimFinancial.Api.Registrars;

public class ApplicationServicesRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IAccountService, AccountService>();
    }
}

