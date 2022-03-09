using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace DataAccess.DbAccess;

public class SqliteDataAccess : ISqliteDataAccess
{
    private readonly string connectionString;

    public SqliteDataAccess(string ConnectionString)
    {
        connectionString = ConnectionString;
    }

    public Task<IEnumerable<T>> LoadData<T, U>(string query,
                                               U parameters)
    {
        using IDbConnection connection = new SqliteConnection(connectionString);

        return connection.QueryAsync<T>(query, new DynamicParameters(parameters));
    }

    public Task SaveData<T>(string query,
                            T parameters)
    {
        using IDbConnection connection = new SqliteConnection(connectionString);

        return connection.ExecuteAsync(sql: query,
                                       param: parameters);
    }
}
