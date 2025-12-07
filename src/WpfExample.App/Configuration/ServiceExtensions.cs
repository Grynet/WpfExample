using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfExample.App.Factories;
using WpfExample.App.Mvvm.ViewModels;
using WpfExample.App.Mvvm.Views;
using WpfExample.App.Repositories;


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
            services.AddScoped<MainWindow>();
        }

        public static void RegisterViewModels(this IServiceCollection services)
        {
            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<HeaderViewModel>();
            services.AddScoped<BodyViewModel>();

            services.AddTransient<HomeViewModel>();
            services.AddTransient<ProductsViewModel>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductInMemoryRepository>();
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
