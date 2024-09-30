
using SlimFinancial.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.RegisterServices(typeof(Program)); // Register 
var app = builder.Build();
app.RegisterPipelineComponents(typeof(Program));
app.Run();
