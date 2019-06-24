using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class PromotionReposatory : Reposatory<Promotion>,IPromotionReposatory
    {
        public PromotionReposatory(MyContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}
