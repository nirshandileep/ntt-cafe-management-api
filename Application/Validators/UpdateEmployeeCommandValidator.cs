using NTT.CafeManagement.Application.Commands.Employee;

namespace NTT.CafeManagement.Application.Validators
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.Employee.Name)
                .NotEmpty()
                .WithMessage("Employee Name is required");
            RuleFor(x => x.Employee.Email)
                .NotEmpty()
                .WithMessage("Employee Email is required");
            RuleFor(x => x.Employee.PhoneNumber)
                .NotEmpty()
                .WithMessage("Employee PhoneNumber is required.")
                .Matches(@"^[89]\d{7}$")
                .WithMessage("Employee PhoneNumber must start with 8 or 9 and have exactly 8 digits.");
            RuleFor(x => x.Employee.Gender)
                .NotEmpty()
                .WithMessage("Employee Gender is required");
        }
    }
}
