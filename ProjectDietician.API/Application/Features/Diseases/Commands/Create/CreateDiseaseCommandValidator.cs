using FluentValidation;

namespace Application.Features.Diseases.Commands.Create {
    public class CreateDiseaseCommandValidator : AbstractValidator<CreateDiseaseCommand> {
        public CreateDiseaseCommandValidator () {
            RuleFor (p => p.Name)
                .NotEmpty ()
                .WithMessage ("{Name} is required.")
                .NotNull ()
                .MaximumLength (30)
                .WithMessage ("{Name} must not exceed 30 characters.");
        }
    }
}