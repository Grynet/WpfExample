using System.Windows;

namespace WpfExample.App.Factories
{
    public interface IAbstractWindowFactory<TWindow> where TWindow : Window
    {
        TWindow Create();
    }
}