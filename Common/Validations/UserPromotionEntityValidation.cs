using FluentValidation;
using Models;

namespace Common.Validations
{
    public class UserPromotionEntityValidation : AbstractValidator<UserPromotion>
    {
        public UserPromotionEntityValidation()
        {
            RuleFor(a => a.Prom_Id).NotEmpty().WithMessage("Promotion Id is Required");
            RuleFor(a => a.User_Id).NotEmpty().WithMessage("User Id is Required");
        }
    }
}
