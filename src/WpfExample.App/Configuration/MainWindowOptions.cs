using System.ComponentModel.DataAnnotations;

namespace WpfExample.App.Configuration
{    public class MainWindowOptions
    {
        public const string Position = "MainWindow";

        [Required]
        [RegularExpression(@"^[A-Za-z ]{1,40}$")]
        public required string WindowTitle { get;set; }
    }
}
