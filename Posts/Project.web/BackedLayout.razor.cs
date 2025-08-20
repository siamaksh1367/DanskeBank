using Microsoft.AspNetCore.Components;

namespace Project.web
{
    public partial class BackedLayout
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public void GoBack_Handling()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}