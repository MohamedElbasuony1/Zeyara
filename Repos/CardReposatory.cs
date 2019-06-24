using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class CardReposatory : Reposatory<Card>,ICardReposatory
    {
        public CardReposatory(MyContext context, IUnitOfWork unitOfWork)
             : base(context, unitOfWork)
        {
        }
    }
}
