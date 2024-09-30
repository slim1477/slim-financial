namespace SlimFinancial.Api.Registrars.Common;

    public interface IWebApplicationRegistrar : IRegistrar
    {
    public void RegisterPipelineComponents(WebApplication app);
    }

