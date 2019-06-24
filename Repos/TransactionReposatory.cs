using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class TransactionReposatory : Reposatory<Transaction>,ITransactionReposatory
    {
        public TransactionReposatory(MyContext context, IUnitOfWork unitOfWork)
         : base(context, unitOfWork)
        {
        }
    }
}
