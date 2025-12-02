using System.Windows;
using WpfExample.App.Mvvm.ViewModels;

namespace WpfExample.App.Mvvm.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();            
            DataContext = viewModel;
        }
    }
}