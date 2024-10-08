using _0_Framework.Application;

namespace CommentManagement.Application.Contracts.CommentApplication
{
    public interface ICommentApplication
    {
        OperationResulte Add(AddComment command);
        OperationResulte Confirm(long id);
        OperationResulte Cancel(long id);
        List<CommentViewModel> Search(CommentSearchModel searchModel);
        public List<CommentViewModel> GetListComment();
    }
}
