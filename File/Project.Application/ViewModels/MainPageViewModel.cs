using CommunityToolkit.Mvvm.ComponentModel;
using Project.Application.Services;
using Project.Core.Engine;
using System.Threading.Tasks;

namespace Project.Application.ViewModels
{
    public partial class MainPageViewModel:ObservableObject
    {
        private readonly IMainProcessor _mainProcessor;
        private readonly IFolderPickerService _folderPickerService;
        [ObservableProperty]
        public BrowseViewModel _browseViewModel;

        [ObservableProperty]
        public WordsListViewModel _wordsListViewModel;

        public MainPageViewModel(IMainProcessor mainProcessor, IFolderPickerService folderPickerService)
        {
            _folderPickerService = folderPickerService;
            _mainProcessor = mainProcessor;
            BrowseViewModel = new BrowseViewModel(_folderPickerService);
            BrowseViewModel.FolderSelected += BrowseViewModel_FolderSelected;
        }

        private async Task BrowseViewModel_FolderSelected(string arg)
        {
            WordsListViewModel = new WordsListViewModel();
            var results = await _mainProcessor.ProcessAsync(arg as string);

            WordsListViewModel.WordCountViewModels = new System.Collections.ObjectModel.ObservableCollection<WordCountViewModel>();
            foreach (var x in results)
            {
                WordsListViewModel.WordCountViewModels.Add(new WordCountViewModel
                {
                    Word = x.Key,
                    Count = x.Value
                });
            }
        }
    }
}
