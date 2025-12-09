using Microsoft.Extensions.Options;
using WpfExample.App.Configuration;

namespace WpfExample.App.Presentation
{
    public class HeaderViewModel
    {
        public HeaderViewModel(IOptions<UiOptions> options)
        {
            Title = options.Value.Title;
        }

        public string Title { get; init; }
    }
}
