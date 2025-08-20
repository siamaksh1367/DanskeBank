using Project.common;
using Project.core.Services.ContentStorage;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();
builder.Configuration.AddUserSecrets("e64bca12-59f5-46cf-ae0d-1444a00b105a");
builder.Configuration.AddEnvironmentVariables();
var sql = builder.Configuration.GetSection(nameof(StorageConnectionString)).Get<StorageConnectionString>();
builder.Services.Configure<StorageConnectionString>(builder.Configuration.GetSection(nameof(StorageConnectionString)));
// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Services.AddTransient<IContentStorage, ContentBlobStorage>();

builder.Build().Run();
