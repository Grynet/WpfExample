using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace WpfExample.App.Mvvm.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(HeaderViewModel headerViewModel, BodyViewModel body)
        {
            Header = headerViewModel;
            Body = body;
            LoadDataCommand = new AsyncRelayCommand(LoadDataAsync);
            LoadDataCommand.Execute(null);
        }
        public IAsyncRelayCommand LoadDataCommand { get; }
        public HeaderViewModel Header { get; }
        public BodyViewModel Body { get; }

        private async Task LoadDataAsync()
        {
            await Task.Delay(5_000);
        }
    }
}
