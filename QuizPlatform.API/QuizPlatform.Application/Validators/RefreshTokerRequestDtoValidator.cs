using FluentValidation;
using QuizPlatform.Application.Dto.User;

namespace QuizPlatform.Application.Validators
{
    public class RefreshTokerRequestDtoValidator : AbstractValidator<RefreshTokerRequestDto>
    {
        public RefreshTokerRequestDtoValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty().WithMessage("Refresh token is required")
                .NotNull().WithMessage("Refresh token cannot be null")
                .MinimumLength(32).WithMessage("Refresh token must be at least 32 characters long")
                .MaximumLength(500).WithMessage("Refresh token must not exceed 500 characters");
        }
    }
}
