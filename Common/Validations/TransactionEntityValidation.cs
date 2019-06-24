using FluentValidation;
using Models;

namespace Common.Validations
{
    public class TransactionEntityValidation:AbstractValidator<Transaction>
    {
        public TransactionEntityValidation()
        {
            RuleFor(a => a.Date).NotEmpty().WithMessage("Date is Required");
            RuleFor(a=>a.Location).NotEmpty().WithMessage("Location is Required");
            RuleFor(a=>a.Doctor_Id).NotEmpty().WithMessage("Doctor Id is Required");
            RuleFor(a=>a.Patient_Id).NotEmpty().WithMessage("Doctor Id is Required");
        }
    }
}
