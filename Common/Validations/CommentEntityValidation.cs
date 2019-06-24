using FluentValidation;
using Models;

namespace Common.Validations
{
    public class CommentEntityValidation:AbstractValidator<Comment>
    {
        public CommentEntityValidation()
        {
            RuleFor(a => a.Date).NotEmpty().WithMessage("Date is Required");
            RuleFor(a => a.Desc).NotEmpty().WithMessage("Comment Content is Required");
            RuleFor(a => a.UserFrom_Id).NotEmpty().WithMessage("Comment Owner Id is Required");
            RuleFor(a => a.UserTo_Id).NotEmpty().WithMessage("Comment Reciever Id is Required");
        }
    }
}
