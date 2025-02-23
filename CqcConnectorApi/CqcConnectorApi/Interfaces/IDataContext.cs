using System.Data;

namespace CqcConnectorApi.Interfaces;
public interface IDataContext
{
    IDbConnection CreateConnection();  
}