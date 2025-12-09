using System.ComponentModel.DataAnnotations;

namespace WpfExample.App.Configuration
{    public class UiOptions
    {
        public const string Position = "Ui";

        [Required]
        [RegularExpression(@"^[A-Za-z ]{1,40}$")]
        public required string Title { get;set; }
    }
}
