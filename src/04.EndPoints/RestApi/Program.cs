using Framework.Contracts.Identities.Configs;
using Framework.Contracts.UserIdentities;
using Presentation.Configs.Cors;
using Presentation.Configs.Cultures;
using Presentation.Configs.Envelopes;
using Presentation.Configs.HealthChecks;
using Presentation.Configs.Servers;
using Presentation.Configs.Services;
using Presentation.Configs.Swagger;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddControllers();

services
    .AddIdentityFromFramework()
    .AddAuthenticationFromFrameworkForApi(configuration)
    .AddCorsConfigs()
    .AddHealthChecksConfigs()
    .AddRouting()
    .AddHttpContextAccessor()
    .AddUserInfoIdentity()
    .AddSwaggerConfigs();

builder.Host.AddAutofacConfigs(configuration);

var web = builder.WebHost;
web.AddServer(configuration);

var app = builder.Build();
app
    .UseCorsConfigs()
    .UseCultureConfigs()
    .UseEnvelopeConfigsApi()
    .UseSwaggerConfigs()
    .UseHttpsRedirection()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
        endpoints.MapControllers());

app.Run();