using FluentValidation;
using Models;

namespace Common.Validations
{
    public class CertificateEntityValidation:AbstractValidator<Certificate>
    {
        public CertificateEntityValidation()
        {
            RuleFor(a => a.ESSN).NotEmpty().WithMessage("ESSN is Required");
            RuleFor(a => a.ESSN).Length(14).WithMessage("ESSN must be 14 charachters");
            RuleFor(a => a.Certi_Img).NotEmpty().WithMessage("Certification Image is Required");
            RuleFor(a => a.Certi_Title).NotEmpty().WithMessage("Certification Title is Required");
        }
    }
}
