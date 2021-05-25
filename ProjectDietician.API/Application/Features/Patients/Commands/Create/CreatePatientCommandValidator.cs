using FluentValidation;

namespace Application.Features.Patients.Commands.Create {
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand> {
        public CreatePatientCommandValidator () {
            RuleFor (p => p.Name)
                .NotEmpty ()
                .WithMessage ("{Name} is required.")
                .NotNull ()
                .MaximumLength (30)
                .WithMessage ("{Name} must not exceed 30 characters.");
            RuleFor (p => p.IDNumber)
                .NotEmpty ()
                .WithMessage ("{IDNumber} is required.")
                .NotNull ()
                .MaximumLength (11)
                .WithMessage ("{IDNumber} must not exceed 11 characters.");
        }

    }
}