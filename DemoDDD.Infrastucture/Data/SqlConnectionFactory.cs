using Dapper;
using DemoDDD.Application.Abstractions.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DemoDDD.Infrastucture.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Create and open SQL Connection
    /// </summary>
    /// <returns></returns>
    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();        
        return connection;
    }
}
