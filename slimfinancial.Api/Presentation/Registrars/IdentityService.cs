using Microsoft.AspNetCore.Identity;
using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Infrastructure.Data;

namespace SlimFinancial.Api.Registrars;

public class IdentityService : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityCore<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        }).AddEntityFrameworkStores<AppDbContext>();
    }
}

