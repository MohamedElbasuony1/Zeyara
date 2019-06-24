using FluentValidation;
using Models;

namespace Common.Validations
{
    public class PromotionEntityValidation:AbstractValidator<Promotion>
    {
        public PromotionEntityValidation()
        {
            RuleFor(a => a.ExpireDate).NotEmpty().WithMessage("Expire date is Required");
            RuleFor(a => a.Percentage).NotEmpty().WithMessage("Percentage is Required");
        }
    }
}
