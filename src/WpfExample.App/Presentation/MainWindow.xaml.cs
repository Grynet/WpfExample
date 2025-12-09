using System.Windows;

namespace WpfExample.App.Presentation
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();            
            DataContext = viewModel;
        }
    }
}