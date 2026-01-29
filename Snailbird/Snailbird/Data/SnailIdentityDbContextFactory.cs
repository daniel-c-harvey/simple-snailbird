using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Snailbird.Utilities;

namespace Snailbird.Data;

public class SnailIdentityDbContextFactory : IDesignTimeDbContextFactory<SnailIdentityDbContext>
{
    public SnailIdentityDbContext CreateDbContext(string[] args)
    {

        var services = new ServiceCollection();
        
        // Design-time tools run without a SynchronizationContext, so blocking is safe here
        var connection = Environment<PostgresConnection>.LoadOrCreate().GetAwaiter().GetResult();

        services.AddDbContext<SnailIdentityDbContext>(options =>
            options.UseNpgsql(Startup.BuildDatabaseConnection(connection)));

        services.AddIdentityCore<ApplicationUser>(options =>
        {
            // Critical for new identity entities
            options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
        });

        return services.BuildServiceProvider().GetRequiredService<SnailIdentityDbContext>();
    }
}