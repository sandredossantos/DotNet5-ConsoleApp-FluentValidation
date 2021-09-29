using FluentValidation;
using Worker.App.FluentValidation.Entities;

namespace Worker.App.FluentValidation.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotNull().NotEmpty();

            RuleFor(user => user.Age)
                .NotEqual(0).WithMessage("Age must be greater than 0.");

            RuleFor(user => user.Gender)
                .IsInEnum().WithSeverity(Severity.Warning);

            RuleFor(user => user.Weight)
                .GreaterThan(5);

            RuleFor(user => user.Mail)
                .NotNull().EmailAddress().DependentRules(() =>
                {
                    RuleFor(user => user.Phone).NotNull();
                });
        }
    }
}