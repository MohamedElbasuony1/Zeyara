using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class RoleReposatory : Reposatory<Role>,IRoleReposatory
    {
        public RoleReposatory(MyContext context, IUnitOfWork unitOfWork)
          : base(context, unitOfWork)
        {
        }
    }
}
