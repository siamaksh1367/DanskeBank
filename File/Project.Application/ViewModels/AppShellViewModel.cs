using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.ViewModels
{
    public partial class AppShellViewModel:ObservableObject
    {
        [ObservableProperty]
        private MainPageViewModel _mainPageViewModel;
    }
}
