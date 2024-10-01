using Microsoft.EntityFrameworkCore;
using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Infrastructure.Data;

namespace SlimFinancial.Api.Registrars
{
    public class DatabaseRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            //TODO: add dbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString(name: "DefaultConnection"));
            });
        }
    }
}
