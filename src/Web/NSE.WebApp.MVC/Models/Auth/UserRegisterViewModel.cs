using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.MVC.Models.Identity
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The field is min length {0} and max length {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(11, ErrorMessage = "The field has max length {0}")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "The field {0} is in invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} must be  between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string PasswordConfirm { get; set; }
    }
}
