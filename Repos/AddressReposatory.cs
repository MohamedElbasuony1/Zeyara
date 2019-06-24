using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class AddressReposatory : Reposatory<Address>, IAddressReposatory
    {
        public AddressReposatory(MyContext context,IUnitOfWork unitOfWork)
            :base(context, unitOfWork)
        {
        }
    }
}
