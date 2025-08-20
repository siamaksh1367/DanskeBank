using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Application.Services;

namespace Project.Application.ViewModels
{
    public partial class BrowseViewModel:ObservableObject
    {
        [ObservableProperty]
        private string _folderPath;

        public event Func<string, Task>? FolderSelected;

        private readonly IFolderPickerService _folderPicker;

        public BrowseViewModel(IFolderPickerService folderPicker)
        {
            _folderPicker = folderPicker;
        }

        [RelayCommand]
        public async Task BrowseFolder()
        {
            var folderPath = await _folderPicker.PickFolderAsync();
            if (!string.IsNullOrEmpty(folderPath))
            {
                FolderPath = folderPath;
                await Shell.Current.DisplayAlert("Folder Selected", folderPath, "OK");

                if (FolderSelected != null)
                {
                    await FolderSelected.Invoke(folderPath);
                }
            }
        }
    }
}
