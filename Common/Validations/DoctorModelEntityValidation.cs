using DTOs;
using FluentValidation;
using Models;

namespace Common.Validations
{
    public class DoctorModelEntityValidation : AbstractValidator<DoctorModel>
    {
        public DoctorModelEntityValidation()
        {
            RuleFor(a => a.Fname).NotEmpty().WithMessage("First name can not be Empty");
            RuleFor(a => a.Fname).Length(3, 10).WithMessage("First name must be between 3 and 15 charachters");
            RuleFor(a => a.Lname).NotEmpty().WithMessage("Last name can not be Empty");
            RuleFor(a => a.Lname).Length(3, 10).WithMessage("Last name must be between 3 and 15 charachters");
            RuleFor(a => a.Age).NotEmpty().WithMessage("Age is required");
            RuleFor(a => a.Email).NotEmpty().WithMessage("Email is Required");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(a => a.Deleted).NotEmpty().WithMessage("Deleted status is required");
            RuleFor(a => a.Role_Id).NotEmpty().WithMessage("Role Id is required");
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
