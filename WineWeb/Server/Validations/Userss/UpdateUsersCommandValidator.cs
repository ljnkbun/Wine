using FluentValidation;
using WineWeb.Server.Commands.Userss;

namespace WineWeb.Server.Validations.Userss
{
    public class UpdateUsersCommandValidator : AbstractValidator<UpdateUsersCommand>
    {
        public UpdateUsersCommandValidator()
        {
            RuleFor(r => r.Code).NotEmpty().WithMessage("{PropertyName}  is required.")
                .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(r => r.Name).NotEmpty().WithMessage("{PropertyName}  is required.")
                 .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(r => r.Username).NotEmpty().WithMessage("{PropertyName}  is required.")
                 .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(r => r.Password).NotEmpty().WithMessage("{PropertyName}  is required.")
                 .NotNull()
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(100).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

            RuleFor(r => r.Email).NotEmpty().WithMessage("{PropertyName}  is required.")
                 .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
                 .EmailAddress().WithMessage("Kindly enter a valid Email Address. ERROR!")
                 //add regex to validate
                 .Matches("^((?!embryco).)*$").WithMessage("Email Address should not contain embryco");

        }

    }
}
