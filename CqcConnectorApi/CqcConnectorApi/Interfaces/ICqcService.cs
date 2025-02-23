using CqcConnectorApi.Application;
using CqcConnectorApi.Application.GetProvider;
using CqcConnectorApi.Application.GetProviders;

namespace CqcConnectorApi.Interfaces;

public interface ICqcService
{
    /// <summary>
    /// Get a list of providers (by page and page size)
    /// </summary>
    /// <param name="pageRequest"></param>
    /// <returns></returns>
    Task<GetProvidersResponse> GetProviders(PageRequest pageRequest);

    /// <summary>
    /// Get a provider by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<GetProviderResponse> GetProvider(string id);
}