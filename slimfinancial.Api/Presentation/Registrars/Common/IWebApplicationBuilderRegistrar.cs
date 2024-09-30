using SlimFinancial.Api.Extensions;

namespace SlimFinancial.Api.Registrars.Common;

    public interface IWebApplicationBuilderRegistrar : IRegistrar
    {
        void RegisterServices(WebApplicationBuilder builder);
    }


