using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace WpfExample.App.Mvvm.ViewModels
{
    public partial class BodyViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentViewModel;

        public BodyViewModel(HomeViewModel homeViewModel, ProductsViewModel productsViewModel)
        {
            NavigateCommand = new AsyncRelayCommand<object>(Navigate);
            HomeViewModel = homeViewModel;
            ProductsViewModel = productsViewModel;

            CurrentViewModel = HomeViewModel;
        }

        public HomeViewModel HomeViewModel { get; set; }
        public ProductsViewModel ProductsViewModel { get; set; }
        public IAsyncRelayCommand<object> NavigateCommand { get; }


        private async Task Navigate(object navigatableViewModel)
        {  
            CurrentViewModel = navigatableViewModel;             
        }        
    }
}
