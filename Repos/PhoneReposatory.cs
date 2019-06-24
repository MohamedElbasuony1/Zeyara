using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class PhoneReposatory: Reposatory<Phone>,IPhoneReposatory
    {
        public PhoneReposatory(MyContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}
