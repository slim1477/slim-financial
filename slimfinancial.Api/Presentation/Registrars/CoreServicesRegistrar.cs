
using SlimFinancial.Api.Registrars.Common;
using SlimFinancial.Infrastructure.Data.Configurations;


namespace SlimFinancial.Api.Registrars;

    public class CoreServicesRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           
        }
    }

