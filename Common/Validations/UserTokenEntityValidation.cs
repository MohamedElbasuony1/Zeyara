using FluentValidation;
using Models;

namespace Common.Validations
{
    public class UserTokenEntityValidation : AbstractValidator<UserToken>
    {
        public UserTokenEntityValidation()
        {
            RuleFor(a => a.TokenNumber).NotEmpty().WithMessage("Token value is required");
            RuleFor(a => a.Usr_Id).NotEmpty().WithMessage("User Id  is Required");
        }
    }
}
