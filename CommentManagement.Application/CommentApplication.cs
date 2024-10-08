using _0_Framework.Application;
using CommentManagement.Application.Contracts.CommentApplication;
using CommentManagement.Domain.CommentAgg;

namespace CommentManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResulte Add(AddComment command)
        {
            var operation = new OperationResulte();
            var comment = new Comment(command.Name, command.phoneNumber, command.Website, command.Message, 
                command.OwnerRecordId, command.Type, command.ParentId);

            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Cancel(long id)
        {
            var operation = new OperationResulte();
            var comment = _commentRepository.GetById(id);
            if (comment == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            comment.Cancel();
            _commentRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Confirm(long id)
        {
            var operation = new OperationResulte();
            var comment = _commentRepository.GetById(id);
            if (comment == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            comment.Confirm();
            _commentRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            return _commentRepository.Search(searchModel);
        }

        public List<CommentViewModel> GetListComment()
        {
            return _commentRepository.GetListComment();
            
        }

      
    }
}
