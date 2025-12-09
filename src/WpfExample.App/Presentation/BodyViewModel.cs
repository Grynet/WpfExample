using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfExample.App.Presentation.Features.Home;
using WpfExample.App.Presentation.Features.Products;

namespace WpfExample.App.Presentation
{
    public partial class BodyViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentViewModel;

        public BodyViewModel(HomeViewModel homeViewModel, ProductsViewModel productsViewModel)
        {
            NavigateCommand = new RelayCommand<object>(Navigate);
            HomeViewModel = homeViewModel;
            ProductsViewModel = productsViewModel;

            CurrentViewModel = HomeViewModel;
        }

        public HomeViewModel HomeViewModel { get; set; }
        public ProductsViewModel ProductsViewModel { get; set; }
        public IRelayCommand<object> NavigateCommand { get; }


        private void Navigate(object navigatableViewModel)
        {  
            CurrentViewModel = navigatableViewModel;             
        }        
    }
}
