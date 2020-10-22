using Core.Dtos;
using FluentValidation;

namespace Core.Validators
{
    public class RegisterCustomerRequestValidator: AbstractValidator<CustomerRegistrationRequest>
    {
        public RegisterCustomerRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("First name can not be empty or null");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("First name can not be empty or null");
            RuleFor(x => x.MobileNumber).NotNull().NotEmpty().WithMessage("UserName can not be empty or null");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password can not be null or empty");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email address is null or empty").EmailAddress().WithMessage("Not a valid email address");
        }
    }
}
