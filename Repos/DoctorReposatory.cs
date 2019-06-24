using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class DoctorReposatory : Reposatory<Doctor>, IDoctorReposatory
    {
        public DoctorReposatory(MyContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}
