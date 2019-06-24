using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class SpecializationReposatory : Reposatory<Specialization>, ISpecializationReposatory
    {
        public SpecializationReposatory(MyContext context, IUnitOfWork unitOfWork)
          : base(context, unitOfWork)
        {
        }
    }
}
