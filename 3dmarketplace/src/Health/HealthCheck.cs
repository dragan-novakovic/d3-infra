using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;

internal sealed class DatabaseHealthCheck : IHealthCheck
{
    private readonly IConfiguration _config;

    public DatabaseHealthCheck(IConfiguration configuration)
    {
        _config = configuration;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("PostgresLocal")))
        {
            try
            {
                await connection.OpenAsync(cancellationToken);
            }
            catch (NpgsqlException e)
            {
                return HealthCheckResult.Unhealthy(exception: e);
            }
        }

        return HealthCheckResult.Healthy();
    }
}