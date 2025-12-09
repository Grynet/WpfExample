using System;
using System.Windows;

namespace WpfExample.App.Factories
{
    public class AbstractWindowFactory<TWindow> : IAbstractWindowFactory<TWindow> where TWindow : Window
    {
        private readonly Func<TWindow> _windowFactory;

        public AbstractWindowFactory(Func<TWindow> factory)
        {
            _windowFactory = factory;
        }

        public TWindow CreateWindow()
        {
            return _windowFactory();
        }
    }
}
