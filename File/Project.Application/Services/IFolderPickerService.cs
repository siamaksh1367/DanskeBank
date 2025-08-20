
namespace Project.Application.Services
{
    public interface IFolderPickerService
    {
        Task<string?> PickFolderAsync();
    }

}