using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using blogManagement.Application.Contracts.ArticelApplication;
using blogManagement.Application.Contracts.ArticelCategoryApplication;
using BlogManagement.Domain.ArticelAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticelRepository : RepositoryBase<long, Articel>, IArticelRepository
    {
        private readonly ArticelContext _context;
        public ArticelRepository(ArticelContext context) : base(context)
        {
            _context = context;
        }

        public EditArticel? GetDetails(long id)
        {
            return _context.Articels.Select(x => new EditArticel()
            {
                ArticelCategoryId = x.ArticelCategoryId,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Id = x.Id,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                PictureAlte = x.PictureAlte,
                ShortDescription = x.ShortDescription,
                Keywords = x.Keywords,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticelViewModel> Search(ArticelSearchModel searches)
        {
            var query = _context.Articels.Select(x => new ArticelViewModel()
            {
                PublishDate = x.PublishDate.ToFarsi(),
                Title = x.Title,
                Id = x.Id,
                ShortDescription = x.ShortDescription,
                articelCategory = x.ArticelCategory.Name,
                articelCategoryId=x.ArticelCategoryId,
                Picture = x.Picture,
                

            });
            if (!string.IsNullOrWhiteSpace(searches.Title))
                query=query.Where(x => x.Title.Contains(searches.Title));

            if (searches.CategoryId > 0)
                query = query.Where(x => x.articelCategoryId == searches.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

       
    }
}
