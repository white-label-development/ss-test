using CqcConnectorApi.Interfaces;

namespace CqcConnectorApi.Application.GetProviders;

public class GetProvidersQuery(ICqcService cqcService)
{
    private readonly ICqcService _cqcService = cqcService;

    public async Task<GetProvidersResponse> Get(PageRequest pageRequest)
    {
        return await _cqcService.GetProviders(pageRequest);
    }
}
