using _0_Framework.Application;
using BlogManagement.Infrastructure.EFCore;
using KamionLandQuery.Contracts.Blogs;

namespace KamionLandQuery.Querys
{
    public class BlogQuery: IBlogQuery
    {
        private readonly ArticelContext _articelContext;

        public BlogQuery(ArticelContext articelContext)
        {
            _articelContext = articelContext;
        }
        public List<Contracts.Blogs.BlogQueryViewModel> Blogs()
        {
            return _articelContext.Articels.Select(x => new BlogQueryViewModel()
            {
                PublishDate = x.PublishDate.ToFarsi(),
                Title = x.Title,
                Id = x.Id,
                ShortDescription = x.ShortDescription,
                articelCategory = x.ArticelCategory.Name,
                articelCategoryId = x.ArticelCategoryId,
                Picture = x.Picture,
                Picturethum = x.Picturethum,
                slug = x.Slug,

            }).ToList();
        }
    }
}
