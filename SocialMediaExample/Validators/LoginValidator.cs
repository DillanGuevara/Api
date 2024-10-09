using FluentValidation;
using SocialMediaExample.DTOs;

namespace SocialMediaExample.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(login => login.User)
                .NotNull();

            RuleFor(login => login.UserName)
                .NotNull();

            RuleFor(login => login.Password)
                .NotNull();

            RuleFor(login => login.Role)
                .NotNull();
        }
    }
}
