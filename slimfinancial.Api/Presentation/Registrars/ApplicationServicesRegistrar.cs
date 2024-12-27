using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Application.Service;
using SlimFinancial.Infrastructure.Services;

namespace SlimFinancial.Api.Registrars;

/// <summary>
/// Registers application specific services
/// </summary>
public class ApplicationServicesRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IPersonService, PersonService>();
        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<ITransactionService, TransactionService>();
    }
}

