using SlimFinancial.Api.Registrars.Common;

namespace SlimFinancial.Api.Registrars;

    public class AppRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

        app.Use(async (context, next) =>
        {
            await next();
            if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
            { 
                context.Request.Path = "/index/html";
            }
        });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors("default");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
        }
    }

