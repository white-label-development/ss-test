using CqcConnectorApi.Application;
using CqcConnectorApi.Application.GetProviders;
using CqcConnectorApi.Interfaces;

namespace CqcConnectorApi.Infrastructure;

public sealed class CqcService(HttpClient client) : ICqcService
{
    private readonly HttpClient _client = client;

    public async Task<GetProvidersResponse> GetProviders(PageRequest pageRequest)
    {

        string requestUri = $"/public/v1/providers?{pageRequest?.ToString()}";
        var result = await _client.GetFromJsonAsync<GetProvidersResponse>(requestUri);
        return result ?? new GetProvidersResponse();
    }
}
