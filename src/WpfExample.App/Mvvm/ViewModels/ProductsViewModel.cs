using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WpfExample.App.Repositories;

namespace WpfExample.App.Mvvm.ViewModels
{
    public partial class ProductsViewModel : ObservableObject, INavigatableViewModel
    {
        private readonly IProductRepository _productRepository;

        [ObservableProperty]
        private ObservableCollection<ProductViewModel> _products;

        public ProductsViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            LoadDataCommand = new AsyncRelayCommand(LoadDataAsync);
        }       

        public IAsyncRelayCommand LoadDataCommand { get; }

        public async Task<bool> TryNavigateFrom()
        {            
            return true;
        }

        public Task<bool> TryNavigateTo()
        {
            LoadDataCommand.Execute(null);
            return Task.FromResult(true);
        }

        private async Task LoadDataAsync()
        {
            //await Task.Delay(5000);
            var products = await _productRepository.GetAll(CancellationToken.None);
            var productViewModels = products.Select(x => new ProductViewModel(x)).ToList();
            Products = new ObservableCollection<ProductViewModel>(productViewModels);
        }
    }
}

