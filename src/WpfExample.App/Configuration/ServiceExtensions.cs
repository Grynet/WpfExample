using Microsoft.Extensions.DependencyInjection;
using WpfExample.App.Repositories;
using WpfExample.App.View;

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
    }
}
