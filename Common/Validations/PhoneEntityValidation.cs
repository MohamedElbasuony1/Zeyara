using FluentValidation;
using Models;

namespace Common.Validations
{
    public class PhoneEntityValidation:AbstractValidator<Phone>
    {
        public PhoneEntityValidation()
        {
            RuleFor(a => a.Number).NotEmpty().WithMessage("Phone number is required");
            RuleFor(a => a.Number).Length(11).WithMessage("Phone number is invalid");
            RuleFor(a => a.Usr_Id).NotEmpty().WithMessage("User Id is Required");
        }
    }
}
