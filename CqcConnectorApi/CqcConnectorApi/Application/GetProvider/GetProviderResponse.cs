﻿using System.Collections.ObjectModel;

namespace CqcConnectorApi.Application.GetProvider;

public class GetProviderResponse
{
    public string? ProviderId { get; set; }
    public Collection<string>? LocationIds { get; set; }
    public string? OrganisationType { get; set; }
    public string? OwnershipType { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
    public string? BrandId { get; set; }
    public string? BrandName { get; set; }
    public string? RegistrationStatus { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string? CompaniesHouseNumber { get; set; }
    public string? CharityNumber { get; set; }
    public string? Website { get; set; }
    public string? PostalAddressLine1 { get; set; }
    public string? PostalAddressLine2 { get; set; }
    public string? PostalAddressTownCity { get; set; }
    public string? PostalAddressCounty { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Uprn { get; set; }
    public double OnspdLatitude { get; set; }
    public double OnspdLongitude { get; set; }
    public string? MainPhoneNumber { get; set; }
    public string? InspectionDirectorate { get; set; }
    public string? Constituency { get; set; }
    public string? LocalAuthority { get; set; }
    public LastInspection? LastInspection
    {
        get; set;
    }    
}
