using DAL;
using Models;
using Repos;

namespace Contracts
{
    public class CertificateReposatory : Reposatory<Certificate>, ICertificateReposatory
    {
        public CertificateReposatory(MyContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}
