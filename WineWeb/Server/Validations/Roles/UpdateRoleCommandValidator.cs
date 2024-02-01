using FluentValidation;
using WineWeb.Server.Commands.Roles;

namespace WineWeb.Server.Validations.Roles
{
    public class UpdateRolesCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRolesCommandValidator()
        {
            RuleFor(r => r.Code).NotEmpty().WithMessage("{PropertyName}  is required.")
                .NotNull()
               .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(r => r.Name).NotEmpty().WithMessage("{PropertyName}  is required.")
                 .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            

        }

    }
}
