using System.Threading.Tasks;

namespace WpfExample.App.Mvvm.ViewModels
{
    public class HomeViewModel : INavigatableViewModel
    {
        public Task<bool> TryNavigateFrom()
        {
            return Task.FromResult(true);
        }

        public Task<bool> TryNavigateTo()
        {
            return Task.FromResult(true);
        }
    }
}
