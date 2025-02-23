using CqcConnectorApi.Application;
using CqcConnectorApi.Application.GetProvider;
using CqcConnectorApi.Application.GetProviders;
using CqcConnectorApi.Interfaces;

namespace CqcConnectorApi.Infrastructure;

public sealed class CqcService(HttpClient client) : ICqcService
{
    private readonly HttpClient _client = client;
    private const string _urlPrefix = "/public/v1";

    public async Task<GetProvidersResponse> GetProviders(PageRequest pageRequest)
    {
        string requestUri = $"{_urlPrefix}/providers?{pageRequest?.ToString()}";
        var result = await _client.GetFromJsonAsync<GetProvidersResponse>(requestUri);
        return result ?? new GetProvidersResponse();
    }

    public async Task<GetProviderResponse> GetProvider(string id)
    {
        string requestUri = $"{_urlPrefix}/providers/{id}";
        var result = await _client.GetFromJsonAsync<GetProviderResponse>(requestUri);
        return result ?? new GetProviderResponse();
    }
}
