using CqcConnectorApi.Application;
using CqcConnectorApi.Application.GetProvider;
using CqcConnectorApi.Application.GetProviders;
using CqcConnectorApi.Infrastructure;
using CqcConnectorApi.Interfaces;

static async Task EnsureDatabaseAndTablesExist(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    await dataContext.Init();
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<ICqcService, CqcService>();
builder.Services.AddScoped<GetProvidersQuery>();
builder.Services.AddScoped<GetProviderQuery>();

builder.Services.AddHttpClient<ICqcService, CqcService>((serviceProvider, client) =>
{
    //  TODO AppSecrets. KeyVault etc
    string cqcApiBaseUrl = "https://api.service.cqc.org.uk";
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "65907e17e06440f6b212ded670f54cbb");
    client.BaseAddress = new Uri(cqcApiBaseUrl);
});


var app = builder.Build();

await EnsureDatabaseAndTablesExist(app);

app.UseHttpsRedirection();

app.MapGet("/providers", async (GetProvidersQuery query, int page, int perPage)
    => await query.Get(new PageRequest(page, perPage)));

app.MapGet("/providers/{id}", async (GetProviderQuery query, string id)
    => await query.Get(id));

await app.RunAsync();