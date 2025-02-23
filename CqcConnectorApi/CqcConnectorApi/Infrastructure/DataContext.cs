using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace CqcConnectorApi.Infrastructure;

public sealed class DataContext(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public IDbConnection CreateConnection() => 
        new SqliteConnection(_configuration.GetConnectionString("CqcDatabase"));

    public async Task Init()
    {
        // create database tables if they don't exist
        using var connection = CreateConnection();
        await InitProvider(connection);
    }

    private static async Task InitProvider(IDbConnection? connection)
    {
        var sql = """           
            CREATE TABLE IF NOT EXISTS 
            Provider (
                ProviderId TEXT,
                LocationIds TEXT,
                OrganisationType TEXT,
                OwnershipType TEXT,
                Type TEXT,
                Name TEXT,
                BrandId TEXT,
                BrandName TEXT,
                RegistrationStatus TEXT,
                RegistrationDate DATETIME,
                CompaniesHouseNumber TEXT,
                CharityNumber TEXT,
                Website TEXT,
                PostalAddressLine1 TEXT,
                PostalAddressLine2 TEXT,
                PostalAddressTownCity TEXT,
                PostalAddressCounty TEXT,
                Region TEXT,
                PostalCode TEXT,
                Uprn TEXT,
                OnspdLatitude REAL,
                OnspdLongitude REAL,
                MainPhoneNumber TEXT,
                InspectionDirectorate TEXT,
                Constituency TEXT,
                LocalAuthority TEXT,
                LastInspectionDate DATETIME,
                PRIMARY KEY (ProviderId)
            );

            CREATE TABLE IF NOT EXISTS
            LastInspection (
                Date DATETIME,
                ProviderId TEXT,
                FOREIGN KEY (ProviderId) REFERENCES Provider (ProviderId)
            );
            """;

        await connection.ExecuteAsync(sql);
    }
}
