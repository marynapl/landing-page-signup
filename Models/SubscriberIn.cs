using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LandingPageSignup.Models
{
    public class SubscriberIn: IValidatableObject
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            SubscriberValidator validator = new SubscriberValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item =>
                new ValidationResult(
                    item.ErrorMessage,
                    new[] { item.PropertyName }
                ));
        }
    }

    public class SubscriberValidator: AbstractValidator<SubscriberIn>
    {
        public SubscriberValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Must(x => x.Length <= 50);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().Must(x => x.Length <= 50);
        }
    }
}