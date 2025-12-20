namespace SnailbirdHome.Components.Common;

/// <summary>
/// Encapsulates Open Graph image metadata with default values for Cerebellum Softworks
/// </summary>
public class OgImageMetadata
{
    public required string Url { get; init; }
    public required string Type { get; init; }
    public int Width { get; init; }
    public int Height { get; init; }
    public required string Alt { get; init; }

    /// <summary>
    /// Default Open Graph image for Cerebellum Softworks (1200x630 banner)
    /// </summary>
    public static OgImageMetadata Default => new()
    {
        Url = "/img/csw-brain-4-banner.png",
        Type = "image/png",
        Width = 1200,
        Height = 630,
        Alt = "Cerebellum Softworks logo"
    };

    /// <summary>
    /// Creates a custom Open Graph image with specified URL, using default dimensions for 1200x630
    /// </summary>
    public static OgImageMetadata FromUrl(string url, string alt = "Cerebellum Softworks logo") => new()
    {
        Url = url,
        Type = "image/png",
        Width = 1200,
        Height = 630,
        Alt = alt
    };

    /// <summary>
    /// Creates a custom Open Graph image with full control over all properties
    /// </summary>
    public static OgImageMetadata Custom(string url, int width, int height, string type = "image/png", string alt = "Cerebellum Softworks logo") => new()
    {
        Url = url,
        Type = type,
        Width = width,
        Height = height,
        Alt = alt
    };
}

/// <summary>
/// Complete SEO metadata for a page
/// </summary>
public class PageSeoMetadata
{
    public string Title { get; init; } = "Cerebellum Softworks";
    public string Description { get; init; } = "Custom software solutions, live captioning services, and software maintenance for businesses worldwide.";
    public OgImageMetadata Image { get; init; } = OgImageMetadata.Default;
    public string OgType { get; init; } = "website";
    public bool NoIndex { get; init; } = false;

    /// <summary>
    /// Optional canonical URL override. If null, will use current request URL at runtime.
    /// Only set this if you need a different canonical URL than the current page.
    /// </summary>
    public string? CanonicalUrlOverride { get; init; }

    /// <summary>
    /// Optional Twitter-specific image. If null, will use the standard Image property.
    /// Twitter prefers square or 2:1 images (e.g., 800x800 or 800x418).
    /// </summary>
    public OgImageMetadata? TwitterImage { get; init; }

    /// <summary>
    /// Default Twitter image for Cerebellum Softworks (800x800 square)
    /// </summary>
    public static OgImageMetadata DefaultTwitterImage => new()
    {
        Url = "/img/csw-brain-4-twitter.png",
        Type = "image/png",
        Width = 800,
        Height = 800,
        Alt = "Cerebellum Softworks logo"
    };
}
