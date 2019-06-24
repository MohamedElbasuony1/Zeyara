using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class UserTokenReposatory : Reposatory<UserToken>, IUserTokenReposatory
    {
        public UserTokenReposatory(MyContext context,IUnitOfWork unitOfWork)
            :base(context, unitOfWork)
        {
        }
    }
}
