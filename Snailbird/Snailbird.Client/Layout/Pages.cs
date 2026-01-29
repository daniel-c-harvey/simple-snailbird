using MudBlazor;

namespace Snailbird.Client.Layout
{
    public class PageRoute
    {
        public string Name { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public string? Icon { get; set; } = null;
    }
    public static class Pages
    {
        public static readonly List<PageRoute> MenuPages =
        [
            new() { Name = "Studio", Route = "/solutions", Icon = Icons.Material.Filled.MusicNote },
        ];

        public static readonly List<PageRoute> AllPages = 
            new List<PageRoute>
            {
                new() { Name = "Home", Route = "/", Icon = Icons.Material.Filled.Home }
            }.Concat(MenuPages).ToList();
    }
}