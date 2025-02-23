using CqcConnectorApi.Interfaces;
using Dapper;

namespace CqcConnectorApi.Application.GetProvider;

public class GetProviderQuery(ICqcService cqcService, IDataContext dataContext)
{
    private readonly ICqcService _cqcService = cqcService;
    private readonly IDataContext _dataContext = dataContext;

    public async Task<GetProviderResponse> Get(string id)
    {
        using var connection = _dataContext.CreateConnection();
        var provider = await connection.QueryFirstOrDefaultAsync<GetProviderResponse>(
            """
	        SELECT ProviderId, LocationIds, OrganisationType, OwnershipType, Type, Name, BrandId, BrandName, 
	               RegistrationStatus, RegistrationDate, CompaniesHouseNumber, CharityNumber, Website, 
	               PostalAddressLine1, PostalAddressLine2, PostalAddressTownCity, PostalAddressCounty, 
	               Region, PostalCode, Uprn, OnspdLatitude, OnspdLongitude, MainPhoneNumber, 
	               InspectionDirectorate, Constituency, LocalAuthority, LastInspectionDate, InsertDate
	        FROM Provider
	        WHERE ProviderId = @ProviderId
	        AND InsertDate >= DATE('now', '-1 month')
	        """,
            new { ProviderId = id }
        );

        if (provider is not null)
        {                                              
            return provider;
        }

        provider =  await _cqcService.GetProvider(id);

        if (provider is not null)
        {
            provider.InsertDate = DateTime.UtcNow;
            await connection.ExecuteAsync(
                """
                INSERT INTO Provider (
                    ProviderId, LocationIds, OrganisationType, OwnershipType, Type, Name, BrandId, BrandName, 
                    RegistrationStatus, RegistrationDate, CompaniesHouseNumber, CharityNumber, Website, 
                    PostalAddressLine1, PostalAddressLine2, PostalAddressTownCity, PostalAddressCounty, 
                    Region, PostalCode, Uprn, OnspdLatitude, OnspdLongitude, MainPhoneNumber, 
                    InspectionDirectorate, Constituency, LocalAuthority, LastInspectionDate, InsertDate
                )
                VALUES (
                    @ProviderId, @LocationIds, @OrganisationType, @OwnershipType, @Type, @Name, @BrandId, @BrandName, 
                    @RegistrationStatus, @RegistrationDate, @CompaniesHouseNumber, @CharityNumber, @Website, 
                    @PostalAddressLine1, @PostalAddressLine2, @PostalAddressTownCity, @PostalAddressCounty, 
                    @Region, @PostalCode, @Uprn, @OnspdLatitude, @OnspdLongitude, @MainPhoneNumber, 
                    @InspectionDirectorate, @Constituency, @LocalAuthority, @LastInspectionDate, @InsertDate
                )
                """,
                new
                {
                    provider.ProviderId,
                    LocationIds = provider.LocationIds != null ? string.Join(",", provider.LocationIds) : null,
                    provider.OrganisationType,
                    provider.OwnershipType,
                    provider.Type,
                    provider.Name,
                    provider.BrandId,
                    provider.BrandName,
                    provider.RegistrationStatus,
                    provider.RegistrationDate,
                    provider.CompaniesHouseNumber,
                    provider.CharityNumber,
                    provider.Website,
                    provider.PostalAddressLine1,
                    provider.PostalAddressLine2,
                    provider.PostalAddressTownCity,
                    provider.PostalAddressCounty,
                    provider.Region,
                    provider.PostalCode,
                    provider.Uprn,
                    provider.OnspdLatitude,
                    provider.OnspdLongitude,
                    provider.MainPhoneNumber,
                    provider.InspectionDirectorate,
                    provider.Constituency,
                    provider.LocalAuthority,
                    LastInspectionDate = provider.LastInspection?.Date,
                    provider.InsertDate
                }
            );
        }

        return provider ?? new GetProviderResponse();
    }
}
