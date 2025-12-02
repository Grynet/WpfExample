using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfExample.App.Factories;
using WpfExample.App.Mvvm.ViewModels;
using WpfExample.App.Mvvm.Views;


namespace WpfExample.App.Configuration
{
    public static class ServiceExtensions
    {
        public static void RegisterOptions(this IServiceCollection services)
        {
            services.AddOptionsWithValidateOnStart<UiOptions>()
                .BindConfiguration(UiOptions.Position)
                .ValidateDataAnnotations();
        }

        public static void RegisterWindows(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
        }

        public static void RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<HeaderViewModel>();
            services.AddSingleton<BodyViewModel>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {

        }

        public static void RegisterFactories(this IServiceCollection services)
        {

        }

        private static void RegisterAbstractWindowFactory<TWindow>(this IServiceCollection services) where TWindow : Window
        {
            services.AddSingleton<Func<TWindow>>(x => () => x.GetService<TWindow>());
            services.AddSingleton<IAbstractWindowFactory<TWindow>, AbstractWindowFactory<TWindow>>();
        }
    }
}
