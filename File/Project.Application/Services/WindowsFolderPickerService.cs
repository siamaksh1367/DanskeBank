#if WINDOWS
using Windows.Storage.Pickers;
using WinRT.Interop;
using Microsoft.UI.Xaml;
using Project.Application.Services;

public class WindowsFolderPickerService : IFolderPickerService
{
    public async Task<string?> PickFolderAsync()
    {
        var picker = new FolderPicker();
        picker.SuggestedStartLocation = PickerLocationId.Desktop;
        picker.FileTypeFilter.Add("*");

        var hwnd = ((MauiWinUIWindow)Microsoft.Maui.Controls.Application.Current.Windows[0].Handler.PlatformView).WindowHandle;
        InitializeWithWindow.Initialize(picker, hwnd);

        var folder = await picker.PickSingleFolderAsync();
        return folder?.Path;
    }
}
#endif
