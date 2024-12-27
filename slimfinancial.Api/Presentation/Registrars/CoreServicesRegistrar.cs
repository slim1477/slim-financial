
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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("default", builder =>
                {
                    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });
            });
            builder.Services.AddSwaggerGen();
           
        }
    }

//o => o.AddPolicy("MyPolicy", builder =>
//{
//    builder.WithOrigins("*")
//           .AllowAnyMethod()
//           .AllowAnyHeader();