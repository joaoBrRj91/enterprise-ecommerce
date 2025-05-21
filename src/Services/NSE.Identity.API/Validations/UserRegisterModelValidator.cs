using FluentValidation;
using NSE.Identity.API.Models;

namespace NSE.Identity.API.Validations
{
    public class UserRegisterModelValidator : AbstractValidator<UserRegister>
    {
        public UserRegisterModelValidator()
        {
            Include(new UserDataModelValidator());

            RuleFor(p => p.Password)
                .NotEqual(p => p.PasswordConfirm)
                .WithMessage("The password not match with the confirmed");
        }
    }
}
