using FluentValidation;
using WineWeb.Server.Commands.Locations;

namespace WineWeb.Server.Validations.Locations
{
    public class CreateLocationsCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationsCommandValidator()
        {
            RuleFor(r => r.Code).NotEmpty().WithMessage("{PropertyName}  is required.")
                 .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(r => r.Name).NotEmpty().WithMessage("{PropertyName}  is required.")
                 .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
           
        }

    }
}
