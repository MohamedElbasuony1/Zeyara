using FluentValidation;
using Models;

namespace Common.Validations
{
    class OnlineUserEntityValidation:AbstractValidator<OnlineUser>
    {
        public OnlineUserEntityValidation()
        {
            RuleFor(a => a.Usr_Id).NotEmpty().WithMessage("User Id is Required");
            RuleFor(a => a.ConnectionId).NotEmpty().WithMessage("Connection Id is Required");
        }
    }
}
