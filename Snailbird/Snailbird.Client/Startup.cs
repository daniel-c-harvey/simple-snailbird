using Snailbird.Client.Services;

namespace Snailbird.Client;

public static class Startup
{
    public static void AddSnailbirdServices(this IServiceCollection services)
    {
        services
            .AddSingleton<SnailbirdThemeFactory>()
            .AddScoped<ReconnectBehavior>();
    }
}