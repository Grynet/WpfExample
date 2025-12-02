namespace WpfExample.App.Mvvm.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(HeaderViewModel headerViewModel, BodyViewModel body)
        {
            Header = headerViewModel;
            Body = body;
        }

        public HeaderViewModel Header { get; }
        public BodyViewModel Body { get; }
    }
}
