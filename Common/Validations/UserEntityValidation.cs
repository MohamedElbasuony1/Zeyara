using FluentValidation;
using Models;

namespace Common.Validations
{
    class UserEntityValidation:AbstractValidator<User>
    {
        public UserEntityValidation()
        {
            
            RuleFor(a => a.Fname).NotEmpty().WithMessage("First name can not be Empty");
            RuleFor(a => a.Fname).Length(3, 10).WithMessage("First name must be between 3 and 15 charachters");
            RuleFor(a => a.Lname).NotEmpty().WithMessage("Last name can not be Empty");
            RuleFor(a => a.Lname).Length(3, 10).WithMessage("Last name must be between 3 and 15 charachters");
            RuleFor(a => a.Age).NotEmpty().WithMessage("Birth date is required");
            RuleFor(a => a.Gender).NotEmpty().WithMessage("Gender is required");
            RuleFor(a => a.Email).NotEmpty().WithMessage("Email is Required");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Password is required");
            //RuleFor(a => a.CPassword).NotEmpty().WithMessage("Confirm Password is required");
            //RuleFor(a => a.CPassword).NotEqual(a => a.Password).WithMessage("Confirm password not match Password");
        }
    }
}
