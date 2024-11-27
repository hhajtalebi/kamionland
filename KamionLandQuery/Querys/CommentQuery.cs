using _0_Framework.Application;
using CommentManagement.Domain.CommentAgg;
using KamionLandQuery.Contracts.comment;

namespace KamionLandQuery.Querys
{
    public class CommentQuery:ICommentQuery
    {
        private readonly ICommentRepository _commentRepository;

        public CommentQuery(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public List<CommentQueryModel> GetDetailes(long Id,int type)
        {
            return _commentRepository.GetAll().Where(x=>x.IsConfirmed&&x.OwnerRecordId==Id&&x.Type==type).Select(x=>new CommentQueryModel()
            {
                Id = x.Id,
                Message = x.Message,
                Name = x.Name,
                OwnerRecordId = x.OwnerRecordId,
                ParentId = x.ParentId,
                PhoneNumber = x.PhoneNumber,
                Type = x.Type,
                Website = x.Website,
                CreateDate = x.CreationDateTime.Date.ToFarsi()
            }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
