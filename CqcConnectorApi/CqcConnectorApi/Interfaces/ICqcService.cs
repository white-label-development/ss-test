using CqcConnectorApi.Application;
using CqcConnectorApi.Application.GetProviders;

namespace CqcConnectorApi.Interfaces;

public interface ICqcService
{
    Task<GetProvidersResponse> GetProviders(PageRequest pageRequest);
}