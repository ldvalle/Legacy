using System.Data.Common;
using System.Data.Odbc;
using Microsoft.Extensions.Options;
using Legacy.Models;

namespace Legacy.Controllers;

public sealed class InformixConnection
{

    private readonly InformixOptions _options;

    public InformixConnection(IOptions<InformixOptions> options)
    {
        _options = options.Value;
    }


    public OdbcConnection CreateConnection()
    {
        var connectionString = $"DRIVER={{IBM INFORMIX ODBC DRIVER (64-bit)}};HOST={_options.Host};SERVICE={_options.Port};SERVER={_options.Server};DATABASE={_options.Database};UID={_options.UserId};PWD={_options.Password};";
        return new OdbcConnection(connectionString);
    }

    public string? GetString(DbDataReader reader, int ordinal) =>
        reader.IsDBNull(ordinal) ? null : reader.GetValue(ordinal).ToString()?.Trim();

}
