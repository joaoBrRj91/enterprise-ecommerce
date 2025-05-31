using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.MVC.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "The field {0} is in invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Password { get; set; }
    }
}
