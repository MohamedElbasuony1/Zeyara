using FluentValidation;
using Models;

namespace Common.Validations
{
    public class CardEntityValidation:AbstractValidator<Card>
    {
        public CardEntityValidation()
        {
            RuleFor(a => a.Number).NotEmpty().WithMessage("Card number is required");
            RuleFor(a => a.Number).CreditCard().WithMessage("Invalid Credit card number");
            RuleFor(a => a.Card_Type).NotEmpty().WithMessage("Card type is Required");
        }
    }
}
