using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class UserReposatory : Reposatory<User>, IUserReposatory
    {
        public UserReposatory(MyContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
        {
        }
    }
}
