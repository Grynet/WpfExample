using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace WpfExample.App.Mvvm.ViewModels
{
    public partial class BodyViewModel : ObservableObject
    {
        [ObservableProperty]
        private INavigatableViewModel _currentViewModel;

        public BodyViewModel(HomeViewModel homeViewModel, ProductsViewModel productsViewModel)
        {
            NavigateCommand = new AsyncRelayCommand<INavigatableViewModel>(Navigate);
            HomeViewModel = homeViewModel;
            ProductsViewModel = productsViewModel;

            CurrentViewModel = HomeViewModel;
        }

        public HomeViewModel HomeViewModel { get; set; }
        public ProductsViewModel ProductsViewModel { get; set; }
        public IAsyncRelayCommand<INavigatableViewModel> NavigateCommand { get; }


        private async Task Navigate(INavigatableViewModel navigatableViewModel)
        {
            var canNavigateFrom = await CurrentViewModel.TryNavigateFrom();

            if (canNavigateFrom)
            {
                var canNavigateTo = await navigatableViewModel.TryNavigateTo();
                if (canNavigateTo) 
                {
                    CurrentViewModel = navigatableViewModel;
                }
            }        
        }        
    }
}
