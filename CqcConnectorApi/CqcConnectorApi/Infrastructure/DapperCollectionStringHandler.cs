using Dapper;
using System.Collections.ObjectModel;
using System.Data;

namespace CqcConnectorApi.Infrastructure;

public class CollectionStringTypeHandler : SqlMapper.TypeHandler<Collection<string>>
{
    public override void SetValue(IDbDataParameter parameter, Collection<string> value)
    {
        ArgumentNullException.ThrowIfNull(parameter);

        parameter.Value = string.Join(",", value);
    }

    public override Collection<string> Parse(object value)
    {
        ArgumentNullException.ThrowIfNull(value);

        return new Collection<string>(value.ToString().Split(','));
    }
}
