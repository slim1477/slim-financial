using Microsoft.AspNetCore.Identity;
using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Domain.Models.Entity;
using SlimFinancial.Infrastructure.Data;

namespace SlimFinancial.Api.Registrars;

public class IdentityService : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityCore<Person>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
}

