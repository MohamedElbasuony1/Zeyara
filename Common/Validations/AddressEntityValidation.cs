using FluentValidation;
using Models;

namespace Common.Validations
{
    public class AddressEntityValidation:AbstractValidator<Address>
    {
        public AddressEntityValidation()
        {
            RuleFor(a => a.AddressType).NotEmpty().WithMessage("Address type value is required");
            RuleFor(a => a.City).NotEmpty().WithMessage("City is Required");
            RuleFor(a => a.Region).NotEmpty().WithMessage("Region is Required");
            RuleFor(a => a.street).NotEmpty().WithMessage("Street is Required");
        }
    }
}
