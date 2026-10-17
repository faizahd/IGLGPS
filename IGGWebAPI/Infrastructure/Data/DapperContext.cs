using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace IGGWebAPI.Infrastructure.Data;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "DefaultConnection is missing.");
    }

    public SqlConnection CreateConnection() =>
        new(_connectionString);
}