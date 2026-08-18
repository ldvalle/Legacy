using System.Data;
using Npgsql;
using IBM.Data.Db2;

namespace Legacy;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}

public class DbConnectionFactory(string connectionString, string databaseType) : IDbConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        if (databaseType == "POSTGRE")
        {
            return new NpgsqlConnection(connectionString);
        }
        else if (databaseType == "IFX")
        {
            return new DB2Connection(connectionString);
        }
        else
        {
            throw new NotSupportedException($"Database type '{databaseType}' is not supported.");
        }

    }
}