namespace SnailbirdHome.Services;

/// <summary>
/// Defines the behavior of the reconnect modal when circuit disconnects
/// </summary>
public enum ReconnectMode
{
    /// <summary>
    /// Silent mode: Attempts reconnection in background without showing modal.
    /// Page content remains visible. Recommended for static pages.
    /// </summary>
    Silent = 0,

    /// <summary>
    /// Visible mode: Shows reconnect modal during disconnection.
    /// Recommended for interactive pages with forms.
    /// </summary>
    Visible = 1
}

/// <summary>
/// Service to control reconnect modal behavior on a per-page basis.
/// Pure state management - JavaScript synchronization is handled by ReconnectBehaviorProvider component.
/// </summary>
public class ReconnectBehavior
{
    /// <summary>
    /// The default reconnection mode for all pages.
    /// </summary>
    public const ReconnectMode DefaultMode = ReconnectMode.Silent;

    /// <summary>
    /// Event that fires when the reconnection mode changes.
    /// </summary>
    public event EventHandler<ReconnectMode>? ModeChanged;

    private ReconnectMode _mode = DefaultMode;

    /// <summary>
    /// Gets or sets the current reconnection behavior mode.
    /// Default is Silent for all pages.
    /// Setting this property fires the ModeChanged event if the value changes.
    /// </summary>
    public ReconnectMode Mode
    {
        get => _mode;
        set
        {
            if (_mode != value)
            {
                _mode = value;
                ModeChanged?.Invoke(this, value);
            }
        }
    }

    /// <summary>
    /// Resets the mode to the default value.
    /// </summary>
    public void Reset()
    {
        Mode = DefaultMode;
    }

    /// <summary>
    /// Gets the current mode as an integer (0 = Silent, 1 = Visible).
    /// </summary>
    public int GetMode() => (int)Mode;
}
