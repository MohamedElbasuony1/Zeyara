using System;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
        Task<int> CommitAsync();
    }
}
