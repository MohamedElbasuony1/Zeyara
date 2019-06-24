using FluentValidation;
using Models;

namespace Common.Validations
{
    public class NotificationEntityValidation:AbstractValidator<Notification>
    {
        public NotificationEntityValidation()
        {
            RuleFor(a => a.Message).NotEmpty().WithMessage("Notification Message is Required");
            RuleFor(a => a.Date).NotEmpty().WithMessage("Date is Required");
            RuleFor(a => a.UserFrom_Id).NotEmpty().WithMessage("Sender Id is Required");
            RuleFor(a => a.UserTo_Id).NotEmpty().WithMessage("Reciever Id is Required");
        }
    }
}
