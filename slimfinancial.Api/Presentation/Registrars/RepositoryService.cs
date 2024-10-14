using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Infrastructure.Data.Repository;

namespace SlimFinancial.Api.Registrars;

public class RepositoryService : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<AccountRepo>();
        builder.Services.AddScoped<TransactionRepo>();
    }
}

