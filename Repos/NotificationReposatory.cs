using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class NotificationReposatory : Reposatory<Notification>,INotificationReposatory
    {
        public NotificationReposatory(MyContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}
