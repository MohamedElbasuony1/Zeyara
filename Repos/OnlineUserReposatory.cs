using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class OnlineUserReposatory : Reposatory<OnlineUser>,IOnlineUserReposatory
    {
        public OnlineUserReposatory(MyContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}
