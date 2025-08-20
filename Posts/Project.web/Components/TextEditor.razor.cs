using Blazored.TextEditor;
using Microsoft.AspNetCore.Components;

namespace Project.web.Components
{
    public partial class TextEditor
    {
        [Parameter]
        public BlazoredTextEditor Reference { get; set; }

        [Parameter]
        public string Text { get; set; }
    }
}
