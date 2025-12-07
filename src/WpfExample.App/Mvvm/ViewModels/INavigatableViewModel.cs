using System.Threading.Tasks;

namespace WpfExample.App.Mvvm.ViewModels
{
    public interface INavigatableViewModel
    {
        Task<bool> TryNavigateTo();
        Task<bool> TryNavigateFrom();
    }
}
