using Microsoft.Extensions.Options;
using System.Windows;
using WpfExample.App.Configuration;

namespace WpfExample.App.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IOptions<MainWindowOptions> options)
        {
            InitializeComponent();
            Title = options.Value.WindowTitle;
        }
    }
}