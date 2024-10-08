using BlogManagement.Domain.ArticelCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using blogManagement.Application.Contracts.ArticelCategoryApplication;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticelCategoryRepository:RepositoryBase<long, ArticelCategory>, IArticelCategoryRepository
    {
        private readonly ArticelContext _context;

        public ArticelCategoryRepository( ArticelContext context) : base(context)
        {
            _context = context;
        }

        public EditArticelCategory? GetDetails(long id)
        {
            return _context.ArticelCategories.Select(x => new EditArticelCategory()
            {
                Id = id,
                Name = x.Name,
                Slug = x.Slug,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                ShowOrder = x.ShowOrder,
                CanonicalAddress = x.CanonicalAddress,
                PictureAlt =x.PictureAlt,
                PictureTitle = x.PictureTitle
        }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticelCategoryViewModel> Search(ArticelCategorySearchModel searchModel)
        {
            var query = _context.ArticelCategories.Include(x=>x.Articels).Select(x=>new ArticelCategoryViewModel()
            {
                Id=x.Id,
                Picture = x.Picture,
                Description = x.Description,
                Name = x.Name,
                ShowOrder = x.ShowOrder,
                creationDate=x.CreationDateTime.ToFarsi(),
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ArticlesCount = x.Articels.Count,

        });

            if (!string.IsNullOrWhiteSpace(searchModel.Name)) 
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.ShowOrder).ToList();
        }


        public List<ArticelCategoryViewModel> GetArticleCategories()
        {
            return _context.ArticelCategories.Select(x => new ArticelCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
