using Application.Features.Diseases.Commands.Create;
using FluentValidation;

namespace Application.Features.Diseases.Commands.Update {
    public class UpdateDiseaseCommandValidator : AbstractValidator<CreateDiseaseCommand> {
        public UpdateDiseaseCommandValidator () {
            RuleFor (p => p.Name)
                .NotEmpty ()
                .WithMessage ("{Name} is required.")
                .NotNull ()
                .MaximumLength (30)
                .WithMessage ("{Name} must not exceed 30 characters.");
        }
    }
}