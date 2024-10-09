using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Application.IService;
using SlimFinancial.Domain.Models.Entity;
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
    }
}

