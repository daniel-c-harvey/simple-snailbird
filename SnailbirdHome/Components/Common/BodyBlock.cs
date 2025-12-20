using MudBlazor;

namespace SnailbirdHome.Components.Common;

public class BodyBlock
{
    public string Text { get; set; }
    public string? Icon { get; set; }
    public Image? Image { get; set; }

    public BodyBlock(string text)
    {
        Text = text;
    }

    public BodyBlock(string text, Image image)
    {
        Text = text;
        Image = image;
    }
    public BodyBlock(string text, string icon)
    {
        Text = text;
        Icon = icon;
    }
}

public class Image
{
    public string Url { get; set; }
    public string Alt { get; set; }

    public Image(string url, string alt)
    {
        Url = url;
        Alt = alt;
    }
}