using Npgsql;
using Snailbird.Utilities;

namespace Snailbird;

internal static class Startup
{
    public static NpgsqlDataSource BuildDatabaseConnection(PostgresConnection connection)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder
        {
            ConnectionStringBuilder =
            {
                Host = connection.Host,
                Port = connection.Port,
                Database = connection.Database,
                Username = connection.Username,
                Password = connection.Password
            }
        };

        return dataSourceBuilder.Build();
    }
}