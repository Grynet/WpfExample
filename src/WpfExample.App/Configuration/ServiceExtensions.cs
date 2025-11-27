using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfExample.App.Factories;
using WpfExample.App.Repositories;
using WpfExample.App.Views;


namespace WpfExample.App.Configuration
{
    public static class ServiceExtensions
    {
        public static void RegisterOptions(this IServiceCollection services)
        {
            services.AddOptionsWithValidateOnStart<MainWindowOptions>()
                .BindConfiguration(MainWindowOptions.Position)
                .ValidateDataAnnotations();
        }

        public static void RegisterViews(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
        }

        public static void RegisterViewModels(this IServiceCollection services)
        {

        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, CustomerInMemoryRepository>();
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
