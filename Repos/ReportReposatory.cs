using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class ReportReposatory : Reposatory<Report>,IReportReposatory
    {
        public ReportReposatory(MyContext context, IUnitOfWork unitOfWork)
           : base(context, unitOfWork)
        {
        }
    }
}
