using System;
using System.Windows;
using System.Windows.Controls;


namespace WpfExample.App.Presentation.Features.Products
{
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is ProductsViewModel viewModel)
                await viewModel.LoadDataCommand.ExecuteAsync(null);
            else
                throw new InvalidOperationException($"{nameof(ProductsView)} requires a viewmodel of type {nameof(ProductsViewModel)}");
        }
    }
}
