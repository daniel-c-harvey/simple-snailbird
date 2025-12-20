using SnailbirdHome.Services;

namespace SnailbirdHome;

public static class Startup
{
    public static void AddCerebellumServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHttpClient()
            .AddSingleton<CerebellumThemeFactory>()
            .AddScoped<ReconnectBehavior>();
    }
}
