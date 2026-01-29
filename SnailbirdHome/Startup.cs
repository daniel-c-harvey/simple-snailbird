using SnailbirdHome.Services;

namespace SnailbirdHome;

public static class Startup
{
    public static void AddSnailbirdServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHttpClient()
            .AddSingleton<SnailbirdThemeFactory>()
            .AddScoped<ReconnectBehavior>();
    }
}
