using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Application.IService;
using SlimFinancial.Infrastructure.Services;

namespace SlimFinancial.Api.Registrars;

/// <summary>
/// Registers application specific services
/// </summary>
public class ApplicationServicesRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<AccountService>();
        builder.Services.AddScoped<TransactionService>();
    }
}

