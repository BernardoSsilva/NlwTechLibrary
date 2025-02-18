using FluentValidation;
using TechLibrary.Comunication.Requests;

namespace TechLibrary.Application.User.post.Validators
{
    class RegisterUserValidator : AbstractValidator<UserRequestJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Email).NotEmpty().WithMessage("User email is required");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Invalid Email");
            RuleFor(user => user.Password).NotEmpty().WithMessage("User password is required");
            RuleFor(user => user.Password.Length).GreaterThan(8);
            When(request => !string.IsNullOrEmpty(request.Password), () => {
                RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(8).WithMessage("password must be bigger than 8 characters");
            });
        }
    }
}
