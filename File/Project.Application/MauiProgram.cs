using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Maui.Controls;
using Project.Application.Services;
using Project.Core.DTO.Configurations;
using Project.Core.Engine;
using Project.Core.FileStreams;
using Project.Core.SourceMonitors;
using Project.Core.TextProcessor;
using Project.Core.Tokenizer.TokenizerFactory;

namespace Project.Application
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            var configurationBuilder = new ConfigurationBuilder();
            var config = configurationBuilder.Build();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

#if WINDOWS
            builder.Services.AddSingleton<IFolderPickerService, WindowsFolderPickerService>();
#else
            builder.Services.AddSingleton<IFolderPickerService, DummyFolderPickerService>();
#endif
            builder.Services.AddTransient<IMainProcessor, MainProcessor>();
            builder.Services.AddTransient<ISourceMonitor<LocalSourceFile>, LocalTextFileMonitor>();
            builder.Services.AddTransient<IFileStreaming, FileStreaming>();
            builder.Services.AddTransient<ITokenizerListFactory, SimpleTokenizerFactory>();
            builder.Services.AddTransient<ITextProcessor, SimpleTextProcessor>();


            return builder.Build();
        }
    }
}
