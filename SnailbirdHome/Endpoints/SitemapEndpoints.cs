namespace SnailbirdHome.Endpoints;

/// <summary>
/// Extension methods for mapping sitemap-related endpoints.
/// </summary>
public static class SitemapEndpoints
{
    public static IEndpointRouteBuilder MapSitemapEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/sitemap.xml", async context =>
        {
            var baseUrl = "https://cerebellumsoftworks.com";
            var lastMod = DateTime.UtcNow.ToString("yyyy-MM-dd");

            var sitemap = $"""
                <?xml version="1.0" encoding="UTF-8"?>
                <urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
                    <url>
                        <loc>{baseUrl}/</loc>
                        <lastmod>{lastMod}</lastmod>
                        <changefreq>weekly</changefreq>
                        <priority>1.0</priority>
                    </url>
                    <url>
                        <loc>{baseUrl}/solutions</loc>
                        <lastmod>{lastMod}</lastmod>
                        <changefreq>weekly</changefreq>
                        <priority>0.9</priority>
                    </url>
                    <url>
                        <loc>{baseUrl}/resume</loc>
                        <lastmod>{lastMod}</lastmod>
                        <changefreq>monthly</changefreq>
                        <priority>0.7</priority>
                    </url>
                </urlset>
                """;

            context.Response.ContentType = "application/xml; charset=utf-8";
            await context.Response.WriteAsync(sitemap);
        });

        return endpoints;
    }
}
