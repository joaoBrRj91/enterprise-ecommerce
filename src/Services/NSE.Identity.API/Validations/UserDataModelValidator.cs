using FluentValidation;
using NSE.Identity.API.Models;

namespace NSE.Identity.API.Validations
{
    public class UserDataModelValidator : AbstractValidator<UserData>
    {
        public UserDataModelValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("{PropertyName} is required in correct format");

            RuleFor(p => p.Password)
                .NotEmpty()
                .Length(6, 50)
                .WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");
        }
    }
}
