using FluentValidation;
using Models;

namespace Common.Validations
{
    public class RoleEntityValidation:AbstractValidator<Role>
    {
        public RoleEntityValidation()
        {
            RuleFor(a => a.Role_Name).NotEmpty().WithMessage("Role name is Required");
        }
    }
}
