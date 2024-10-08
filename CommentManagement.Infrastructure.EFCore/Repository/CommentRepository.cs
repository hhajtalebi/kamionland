using _0_Framework.Application;
using _0_Framework.Infrastructure;
using CommentManagement.Application.Contracts.CommentApplication;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EFCore;

namespace CommentManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _context;

        public CommentRepository(CommentContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _context.Comments
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    phoneNumber = x.PhoneNumber,
                    Website = x.Website,
                    Message = x.Message,
                    OwnerRecordId = x.OwnerRecordId,
                    Type = x.Type,
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    CommentDate = x.CreationDateTime.ToFarsi()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.phoneNumber))
                query = query.Where(x => x.phoneNumber.Contains(searchModel.phoneNumber));

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<CommentViewModel> GetListComment()
        {
            var query = _context.Comments.Where(x=>!x.IsConfirmed)
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    phoneNumber = x.PhoneNumber,
                    Website = x.Website,
                    Message = x.Message,
                    OwnerRecordId = x.OwnerRecordId,
                    Type = x.Type,
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    CommentDate = x.CreationDateTime.ToFarsi()
                });
            return query.OrderByDescending(x=>x.Id).Take(5).ToList();
            
        }
    }
}
