using FluentValidation;
using Models;

namespace Common.Validations
{
    class SpecializationEntityValidation:AbstractValidator<Specialization>
    {
        public SpecializationEntityValidation()
        {
            RuleFor(a => a.Spc_Name).NotEmpty().WithMessage("Specialization name is Required");
        }
    }
}
