using FluentValidation;
using Models;

namespace Common.Validations
{
    public class ReportEntityValidation:AbstractValidator<Report>
    {
        public ReportEntityValidation()
        {
            RuleFor(a => a.Date).NotEmpty().WithMessage("Report Date is Required");
            RuleFor(a => a.Zyara_Date).NotEmpty().WithMessage("Zyara Date is Required");
            RuleFor(a => a.Desc).NotEmpty().WithMessage("Report Description is Required");
            RuleFor(a => a.UserFrom_Id).NotEmpty().WithMessage("Report Owner Date is Required");
            RuleFor(a => a.UserTo_Id).NotEmpty().WithMessage("Report Reciever Date is Required");
        }
    }
}
