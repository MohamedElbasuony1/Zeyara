using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class UserPromotionReposatory : Reposatory<UserPromotion>,IUserPromotionReposatory
    {
        public UserPromotionReposatory(MyContext context, IUnitOfWork unitOfWork)
         : base(context, unitOfWork)
        {
        }
    }
}
