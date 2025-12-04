using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace WpfExample.App.Mvvm.ViewModels
{
    public class BodyViewModel
    {
        public BodyViewModel()
        {
            LoadDataCommand = new AsyncRelayCommand(LoadDataAsync);
            LoadDataCommand.Execute(null);
        }
        public IAsyncRelayCommand LoadDataCommand { get; }

        private async Task LoadDataAsync()
        {
            await Task.Delay(5_000);
        }
    }
}
