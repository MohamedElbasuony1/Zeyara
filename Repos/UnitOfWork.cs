using Contracts;
using DAL;
using System.Threading.Tasks;

namespace Repos
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MyContext _context;
        public UnitOfWork(MyContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
