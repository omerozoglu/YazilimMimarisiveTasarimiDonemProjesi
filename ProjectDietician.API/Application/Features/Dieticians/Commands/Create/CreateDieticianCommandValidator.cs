using FluentValidation;

namespace Application.Features.Dieticians.Commands.Create {
    public class CreateDieticianCommandValidator : AbstractValidator<CreateDieticianCommand> {
        public CreateDieticianCommandValidator () {
            RuleFor (p => p.Name)
                .NotEmpty ()
                .WithMessage ("{Name} is required.")
                .NotNull ()
                .MaximumLength (30)
                .WithMessage ("{Name} must not exceed 30 characters.");
            RuleFor (p => p.Username)
                .NotEmpty ()
                .WithMessage ("{Username} is required.")
                .NotNull ();
            RuleFor (p => p.Password)
                .NotEmpty ()
                .WithMessage ("{Password} is required.")
                .NotNull ();
            RuleFor (p => p.IDNumber)
                .NotEmpty ()
                .WithMessage ("{IDNumber} is required.")
                .NotNull ()
                .MaximumLength (11)
                .WithMessage ("{IDNumber} must not exceed 11 characters.");
        }
    }
}