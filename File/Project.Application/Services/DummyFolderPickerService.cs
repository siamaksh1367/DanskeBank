
using Project.Application.Services;

public class DummyFolderPickerService : IFolderPickerService
{
    public Task<string?> PickFolderAsync()
    {
        return Task.FromResult<string?>(null);
    }
}

