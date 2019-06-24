using Contracts;
using DAL;
using Models;

namespace Repos
{
    public class CommentReposatory : Reposatory<Comment>,ICommentReposatory
    {
        public CommentReposatory(MyContext context, IUnitOfWork unitOfWork)
            : base(context, unitOfWork)
        {
        }
    }
}
