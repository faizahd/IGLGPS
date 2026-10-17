using Dapper;
using IGGWebAPI.Application.Interfaces;
using IGGWebAPI.Domain.Entities;

using IGGWebAPI.Infrastructure.Data;

namespace IGGWebAPI.Infrastructure.Repositories;

public class GPSDeviceRepository : IGPSDeviceRepository
{
    private readonly DapperContext _context;

    public GPSDeviceRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GPSDevice>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT Id, DeviceNumber, DeviceName, Model,
                   IsActive, CreatedAt
            FROM dbo.GPSDevice
            ORDER BY Id DESC;
            """;

        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<GPSDevice>(
            new CommandDefinition(
                sql, cancellationToken: cancellationToken));
    }

    public async Task<GPSDevice?> GetByIdAsync(
        int id, CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT Id, DeviceNumber, DeviceName, Model,
                   IsActive, CreatedAt
            FROM dbo.GPSDevice
            WHERE Id = @Id;
            """;

        using var connection = _context.CreateConnection();

        return await connection.QuerySingleOrDefaultAsync<GPSDevice>(
            new CommandDefinition(
                sql, new { Id = id },
                cancellationToken: cancellationToken));
    }

    public async Task<int> CreateAsync(
        GPSDevice device, CancellationToken cancellationToken)
    {
        const string sql = """
            INSERT INTO dbo.GPSDevice
                (DeviceNumber, DeviceName, Model, IsActive, CreatedAt)
            OUTPUT INSERTED.Id
            VALUES
                (@DeviceNumber, @DeviceName, @Model, @IsActive, @CreatedAt);
            """;

        using var connection = _context.CreateConnection();

        return await connection.ExecuteScalarAsync<int>(
            new CommandDefinition(
                sql, device,
                cancellationToken: cancellationToken));
    }

    public async Task<bool> UpdateAsync(
        GPSDevice device, CancellationToken cancellationToken)
    {
        const string sql = """
            UPDATE dbo.GPSDevice
            SET DeviceNumber = @DeviceNumber,
                DeviceName = @DeviceName,
                Model = @Model,
                IsActive = @IsActive
            WHERE Id = @Id;
            """;

        using var connection = _context.CreateConnection();

        var rows = await connection.ExecuteAsync(
            new CommandDefinition(
                sql, device,
                cancellationToken: cancellationToken));

        return rows > 0;
    }

    public async Task<bool> DeleteAsync(
        int id, CancellationToken cancellationToken)
    {
        const string sql = """
            DELETE FROM dbo.GPSDevice
            WHERE Id = @Id;
            """;

        using var connection = _context.CreateConnection();

        var rows = await connection.ExecuteAsync(
            new CommandDefinition(
                sql, new { Id = id },
                cancellationToken: cancellationToken));

        return rows > 0;
    }
}