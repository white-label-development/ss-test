using CqcConnectorApi.Application.GetProviders;
using CqcConnectorApi.Interfaces;

namespace CqcConnectorApi.Application.GetProvider;

public class GetProviderQuery(ICqcService cqcService)
{
    private readonly ICqcService _cqcService = cqcService;

    public async Task<GetProviderResponse> Get(string id)
    {
        return await _cqcService.GetProvider(id);
    }
}
