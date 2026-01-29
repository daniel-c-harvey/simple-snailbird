using MudBlazor;

namespace SnailbirdHome.Services;

public class SnailbirdThemeFactory
{
    public virtual MudTheme MakeTheme() => new()
    {
        PaletteLight = LightPalette,
        PaletteDark = DarkPalette,
        LayoutProperties = new LayoutProperties(),
        Typography = new Typography()
        {
            Default = new DefaultTypography()
            {
                FontFamily = ["Josefin Sans"]
            },
            Button = new ButtonTypography()
            {
                FontFamily = ["Josefin Sans"]
            },
            H1 = new H1Typography()
            {
                FontFamily = ["Josefin Sans"],
                FontSize = new H2Typography().FontSize,
                FontWeight = "400"
            },
            H2 = new H2Typography()
            {
                FontFamily = ["Josefin Sans"]
            },
            H3 = new H3Typography()
            {
                FontFamily = ["Josefin Sans"]
            },
            H4 = new H4Typography()
            {
                FontFamily = ["Josefin Sans"]
            },
            H5 = new H5Typography()
            {
                FontFamily = ["Josefin Sans"]
            },
            H6 = new H6Typography()
            {
                FontFamily = ["Josefin Sans"]
            },
            Body1 = new Body1Typography()
            {
                FontFamily = ["Commissioner"]
            },
            Body2 = new Body2Typography()
            {
                FontFamily = ["Commissioner"]
            }
        }
    };
    
    protected virtual PaletteLight LightPalette => new()
    {
        Primary = "#00c011",
        PrimaryContrastText = "#ffffff",
        PrimaryDarken = "#009b0d",
        PrimaryLighten = "#33cd3f",
        Secondary = "#2f68b8",
        SecondaryContrastText = "#ffffff",
        SecondaryDarken = "#25529a",
        SecondaryLighten = "#5583c6",
        Tertiary = "#7657b9",
        TertiaryContrastText = "#ffffff",
        TertiaryDarken = "#5e3da0",
        TertiaryLighten = "#9278ca",
        Surface = "#f5f5f5",
        Background = "#fafafa",
        BackgroundGray = "#f0f0f0",
        AppbarText = "#37474F",
        AppbarBackground = "rgba(240,240,240,0.9)",
        DrawerBackground = "#f5f5f5",
        DrawerText = "#37474F",
        DrawerIcon = "#455A64",
        TextPrimary = "#37474F",
        TextSecondary = "#546E7A",
        TextDisabled = "#00000061",
        ActionDefault = "#546E7A",
        ActionDisabled = "#00000026",
        ActionDisabledBackground = "#0000001f",
        GrayDefault = "#bdbdbd",
        GrayLight = "#e0e0e0",
        GrayLighter = "#f5f5f5",
        GrayDark = "#9e9e9e",
        GrayDarker = "#757575",
        Info = "#1976D2",
        InfoContrastText = "#ffffff",
        InfoDarken = "#0D47A1",
        InfoLighten = "#2196F3",
        Success = "#0dbf72",
        SuccessContrastText = "#ffffff",
        SuccessDarken = "#00a660",
        SuccessLighten = "#3dd98e",
        Warning = "#F57C00",
        WarningContrastText = "#ffffff",
        WarningDarken = "#E65100",
        WarningLighten = "#FF9800",
        Error = "#FF1744",
        ErrorContrastText = "#ffffff",
        ErrorDarken = "#D50000",
        ErrorLighten = "#FF5252",
        Dark = "#424242",
        DarkContrastText = "#ffffff",
        DarkLighten = "#616161",
        DarkDarken = "#212121",
        LinesDefault = "#e0e0e0",
        LinesInputs = "#bdbdbd",
        TableLines = "#e0e0e0",
        TableStriped = "#f9f9f9",
        TableHover = "#f5f5f5",
        Divider = "#e0e0e0",
        DividerLight = "#f0f0f0",
        OverlayDark = "#00000052",
        OverlayLight = "#ffffff80",
        HoverOpacity = 0.04,
        RippleOpacity = 0.1,
        Black = "#37474F",
        White = "#ffffff",
    };

    protected virtual PaletteDark DarkPalette => new()
    {
        Primary = "#00c713",
        PrimaryContrastText = "#ECEFF1",
        PrimaryDarken = "#00b010",
        PrimaryLighten = "#33d03f",
        Secondary = "#4a8fff",
        SecondaryContrastText = "#ECEFF1",
        SecondaryDarken = "#3b7dd4",
        SecondaryLighten = "#7aabff",
        Tertiary = "#8b5fd9",
        TertiaryContrastText = "#ECEFF1",
        TertiaryDarken = "#7347c0",
        TertiaryLighten = "#a57fe6",
        Surface = "#2C393F",
        Background = "#1C262A",
        BackgroundGray = "#263238",
        AppbarText = "#B0BEC5",
        AppbarBackground = "rgba(44,57,63,0.8)",
        DrawerBackground = "#2C393F",
        DrawerText = "#B0BEC5",
        DrawerIcon = "#B0BEC5",
        TextPrimary = "#B0BEC5",
        TextSecondary = "#80CBC4",
        TextDisabled = "#ffffff33",
        ActionDefault = "#B0BEC5",
        ActionDisabled = "#9999994d",
        ActionDisabledBackground = "#605f6d4d",
        GrayDefault = "#455A64",
        GrayLight = "#546E7A",
        GrayLighter = "#37474F",
        GrayDark = "#2C393F",
        GrayDarker = "#263238",
        Info = "#42A5F5",
        InfoContrastText = "#ffffff",
        InfoDarken = "#1976D2",
        InfoLighten = "#90CAF9",
        Success = "#00ff90",
        SuccessContrastText = "#1C262A",
        SuccessDarken = "#00cc73",
        SuccessLighten = "#33ffa3",
        Warning = "#ffb545",
        WarningContrastText = "#1C262A",
        WarningDarken = "#FF8F00",
        WarningLighten = "#FFD54F",
        Error = "#FF1744",
        ErrorContrastText = "#ffffff",
        ErrorDarken = "#D50000",
        ErrorLighten = "#FF5252",
        Dark = "#263238",
        DarkContrastText = "#B0BEC5",
        DarkLighten = "#2C393F",
        DarkDarken = "#1C262A",
        LinesDefault = "#205b7a",
        LinesInputs = "#205b7a",
        TableLines = "#205b7a",
        TableStriped = "#324447",
        TableHover = "#293d47",
        Divider = "#2C393F",
        DividerLight = "#37474F",
        OverlayDark = "#00000080",
        OverlayLight = "#26323880",
        HoverOpacity = 0.06,
        RippleOpacity = 0.1,
        Black = "#1C262A",
        White = "#ECEFF1",
    };
}