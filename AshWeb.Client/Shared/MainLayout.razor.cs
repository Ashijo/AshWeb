using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AshWeb.Client.Shared;

public class MainLayoutBase : LayoutComponentBase
{
    protected bool _drawerOpen = true;
    protected bool _isDarkMode = true;
    protected MudThemeProvider? _mudThemeProvider;
    protected void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {

        if (firstRender)
        {
            ArgumentNullException.ThrowIfNull(_mudThemeProvider, $"{nameof(_mudThemeProvider)}  is null");
            _isDarkMode = await _mudThemeProvider.GetSystemPreference();
            StateHasChanged();
        }
    }
}