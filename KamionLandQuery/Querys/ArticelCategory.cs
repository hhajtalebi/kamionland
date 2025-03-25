using BlogManagement.Domain.ArticelAgg;
using BlogManagement.Infrastructure.EFCore;
using KamionLandQuery.Contracts.Blogs.Blog;
using KamionLandQuery.Contracts.Blogs.Blog.ArticelCategory;
using Microsoft.EntityFrameworkCore;

namespace KamionLandQuery.Querys
{
    public class ArticelCategory : IArticelCategory
    {
        private readonly ArticelContext _context;

        public ArticelCategory(ArticelContext context)
        {
            _context = context;
        }
        public List<ArticelCategoryQueryModel> GetArticelCategorys()
        {
            return _context.ArticelCategories
                .Include(x => x.Articels)
                .Select(x => new ArticelCategoryQueryModel
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ArticelCategoryCount = x.Articels.Count(),
                    Slug = x.Slug,
                    Description = x.Description,
                    CanonicalAddress = x.CanonicalAddress,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Name = x.Name,
                    ShowOrder = x.ShowOrder,
                }).ToList();


        }
        public List<ArticelCategoryQueryModel> GetArticelCategorys(long categoryId)
        {
            return _context.ArticelCategories
                .Where(x => x.Id == categoryId).Include(x => x.Articels)
                .Select(x => new ArticelCategoryQueryModel
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ArticelCategoryCount = x.Articels.Count(),
                    Slug = x.Slug,
                    Description = x.Description,
                    CanonicalAddress = x.CanonicalAddress,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Name = x.Name,
                    ShowOrder = x.ShowOrder,
                }).ToList();


        }

        public ArticelCategoryQueryModel? GetArticelCategoryBySlug(string slug)
        {
            return _context.ArticelCategories
                .Include(x => x.Articels)
                .Select(x => new ArticelCategoryQueryModel
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ArticelCategoryCount = x.Articels.Count(),
                    Slug = x.Slug,
                    Description = x.Description,
                    CanonicalAddress = x.CanonicalAddress,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Name = x.Name,
                    ShowOrder = x.ShowOrder,
                    Articels = MapArticels(x.Articels)
                }).FirstOrDefault(x=>x.Slug==slug);
        }

        private static List<ArticelQueryModel> MapArticels(List<Articel> articels)
        {
            return articels.Select(x => new ArticelQueryModel()
            {
                CanonicalAddress = x. CanonicalAddress,
                Keywords = x.Keywords,
                Description = x.Description,
                Id = x.Id,
                Picture = x.Picture,
                PictureAlte = x.PictureAlte,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                PublishDate = x.PublishDate,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                ArticelCategoryId = x.ArticelCategoryId,
              
            }).ToList();
        }

        public List<ArticelCategoryQueryModel> GetArticelCategorysWithArticel()
        {
            return _context.ArticelCategories
                .Include(x => x.Articels)
                .Select(x => new ArticelCategoryQueryModel
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ArticelCategoryCount = x.Articels.Count(),
                    Slug = x.Slug,
                    Description = x.Description,
                    CanonicalAddress = x.CanonicalAddress,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Name = x.Name,
                    ShowOrder = x.ShowOrder,
                    Articels = MapArticels(x.Articels)
                }).ToList();


        }

       
    }
}
