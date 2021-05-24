using FluentValidation;

namespace Application.Features.Foods.Commands.Update {
    public class UpdateFoodCommandValidator : AbstractValidator<UpdateFoodCommand> {
        public UpdateFoodCommandValidator () {
            RuleFor (p => p.Name)
                .NotEmpty ()
                .WithMessage ("{Name} is required.")
                .NotNull ()
                .MaximumLength (30)
                .WithMessage ("{Name} must not exceed 30 characters.");
        }
    }
}