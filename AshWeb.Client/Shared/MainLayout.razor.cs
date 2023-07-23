using MudBlazor;

namespace AshWeb.Client.Shared;

public partial class MainLayout
{
    protected bool _drawerOpen = true;
    protected bool _isDarkMode = true;
    protected MudThemeProvider? _mudThemeProvider;
    protected string ThemeIcon
    {
        get
        {
            return _isDarkMode == true
            ? Icons.Material.Filled.ModeNight
            : Icons.Material.Filled.LightMode;
        }
    }
    protected void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        ArgumentNullException.ThrowIfNull(_mudThemeProvider);
        _isDarkMode = await _mudThemeProvider.GetSystemPreference();
        StateHasChanged();
    }
}