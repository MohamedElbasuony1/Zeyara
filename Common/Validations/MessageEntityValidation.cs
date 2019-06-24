using FluentValidation;
using Models;

namespace Common.Validations
{
    public class MessageEntityValidation:AbstractValidator<Message>
    {
        public MessageEntityValidation()
        {
            RuleFor(a => a.Msg).NotEmpty().WithMessage("Comment message is Required");
            RuleFor(a => a.Date).NotEmpty().WithMessage("Date is Required");
            RuleFor(a => a.UserFrom_Id).NotEmpty().WithMessage("Comment Owner Id is Required");
            RuleFor(a => a.UserTo_Id).NotEmpty().WithMessage("Comment Reciever Id is Required");

        }
    }
}
