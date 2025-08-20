using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Project.Application.ViewModels
{
    public partial class WordsListViewModel:ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<WordCountViewModel> _wordCountViewModels;
    }
}