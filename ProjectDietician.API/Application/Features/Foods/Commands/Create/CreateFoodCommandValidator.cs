using FluentValidation;

namespace Application.Features.Foods.Commands.Create {
    public class CreateFoodCommandValidator : AbstractValidator<CreateFoodCommand> {
        public CreateFoodCommandValidator () {
            RuleFor (p => p.Name)
                .NotEmpty ()
                .WithMessage ("{Name} is required.")
                .NotNull ()
                .MaximumLength (30)
                .WithMessage ("{Name} must not exceed 30 characters.");
        }
    }
}