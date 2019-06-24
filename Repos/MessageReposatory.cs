using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class MessageReposatory : Reposatory<Message>, IMessageReposatory
    {
        public MessageReposatory(MyContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}
