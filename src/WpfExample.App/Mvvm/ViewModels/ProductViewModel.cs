using CommunityToolkit.Mvvm.ComponentModel;
using System;
using WpfExample.App.Mvvm.Models;

namespace WpfExample.App.Mvvm.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {
        private readonly Product _product;

        [ObservableProperty]
        private Guid _id;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _description;
        [ObservableProperty]
        private int _price;

        public ProductViewModel(Product product)
        {
            _product = product;
            _id = product.Id;
            _name = product.Name;
            _description = product.Description;
            _price = product.Price;
        }
    }
}
