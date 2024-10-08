using _0_Framework.Domain;
using CommentManagement.Application.Contracts.CommentApplication;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel searchModel);
        public List<CommentViewModel> GetListComment();
    }
}
