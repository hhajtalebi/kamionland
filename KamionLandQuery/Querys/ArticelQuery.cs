using BlogManagement.Infrastructure.EFCore;
using KamionLandQuery.Contracts.Blogs.Blog;
using Microsoft.EntityFrameworkCore;

namespace KamionLandQuery.Querys
{
    public class ArticelQuery: IArticelQuery
    {
        private readonly ArticelContext _context;

        public ArticelQuery(ArticelContext context)
        {
            _context = context;
        }
        public List<ArticelQueryModel> GetArticel()
        {
            return _context.Articels.Include(x => x.ArticelCategory).Select(x => new ArticelQueryModel
            {
                ArticelCategoryId = x.ArticelCategoryId,
                ArticelCategoryName = x.ArticelCategory.Name,
                Picture = x.Picture,
                Slug = x.Slug,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                PictureAlte = x.PictureAlte,
                ShortDescription = x.ShortDescription,
                Keywords = x.Keywords,
                CanonicalAddress = x.CanonicalAddress,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate,
                Title = x.Title,
                
            }).ToList();
        }

        public ArticelQueryModel? GetDetaile(string slug)
        {
            return _context.Articels.Include(x => x.ArticelCategory).Select(x => new ArticelQueryModel
            {
                ArticelCategoryId = x.ArticelCategoryId,
                ArticelCategoryName = x.ArticelCategory.Name,
                Picture = x.Picturethum,
                Slug = x.Slug,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                PictureAlte = x.PictureAlte,
                ShortDescription = x.ShortDescription,
                Keywords = x.Keywords,
                CanonicalAddress = x.CanonicalAddress,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate,
                Title = x.Title,
                Id = x.Id,
            }).FirstOrDefault(x=>x.Slug==slug);
        }
    }
}
