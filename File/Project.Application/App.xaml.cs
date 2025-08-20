using Project.Application.Services;
using Project.Application.ViewModels;
using Project.Core.Engine;

namespace Project.Application
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        private readonly IFolderPickerService _folderPickerService;
        private readonly IMainProcessor _mainProcessor;

        public App(IFolderPickerService folderPickerService, IMainProcessor mainProcessor)
        {
            InitializeComponent();
            _folderPickerService = folderPickerService;
            _mainProcessor = mainProcessor;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var appShell = new AppShell();
            var appShellViewModel = new AppShellViewModel();
            appShellViewModel.MainPageViewModel = new MainPageViewModel(_mainProcessor,_folderPickerService);
            appShell.BindingContext = appShellViewModel;
            return new Window(appShell);
        }
    }
}