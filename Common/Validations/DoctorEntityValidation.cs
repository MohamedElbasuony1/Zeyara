using FluentValidation;
using Models;

namespace Common.Validations
{
    class DoctorEntityValidation : AbstractValidator<Doctor>
    {
        public DoctorEntityValidation()
        {
            RuleFor(a => a.ESSN).NotEmpty().WithMessage("Doctor ESSN is Required");
            RuleFor(a => a.ESSN).Length(14).WithMessage("ESSN number must be equal 14 numbers");
            RuleFor(a => a.Degree).NotEmpty().WithMessage("Degree is Required");
            RuleFor(a => a.Experience).NotEmpty().WithMessage("Experience is Required");
            RuleFor(a => a.Experience).GreaterThan(1).WithMessage("Experience must be greater than 1 year");
            RuleFor(a => a.Salary).NotEmpty().WithMessage("Salary is Required");
            RuleFor(a => a.Salary).GreaterThan(80).WithMessage("Salary must be greater than 80");
        }
    }
}
