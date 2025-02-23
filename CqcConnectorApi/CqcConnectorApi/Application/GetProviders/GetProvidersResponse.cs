using System.Collections.ObjectModel;

namespace CqcConnectorApi.Application.GetProviders;

public class GetProvidersResponse : PageResponse
{
    public GetProvidersResponse() => Providers = [];
    public Collection<ProviderListing> Providers { get; set; }
}
