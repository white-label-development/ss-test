using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace CqcConnectorApi.Infrastructure;

public sealed class DataContext(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;       
 
    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(_configuration.GetConnectionString("CqcDatabase"));
    }

    public async Task Init()
    {
        // create database tables if they don't exist
        using var connection = CreateConnection();
        await initUsers();

        // TODO actual schema
        async Task initUsers()
        {
            var sql = """
            CREATE TABLE IF NOT EXISTS 
            Users (
                Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                Title TEXT,
                FirstName TEXT,
                LastName TEXT,
                Email TEXT,
                Role INTEGER,
                PasswordHash TEXT
            );
            """;

            await connection.ExecuteAsync(sql);
        }
    }
}
