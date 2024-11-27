using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using FLEXYGO.UI;
using Microsoft.EntityFrameworkCore;
using TrucksManagement.Application.contracts.TrkCategoryApplication;
using TrucksManagement.Domain.TruckCategoryAgg;

namespace TrucksManagement.Infrustructuer.EfCore.Repository
{
    public class TrkCategoryRepository:RepositoryBase<long,TruckCategory>,ITruckCategoryRepository
    {
        private readonly TrcksContext _context;

        public TrkCategoryRepository(TrcksContext context) : base(context)
        {
            _context = context;
        }

        public EditTrkCategory? GetDetailes(long id)
        {
            return _context.TruckCategories.Select(x => new EditTrkCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                ParentId = x.ParentId,
                PictureName=x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitel = x.PictureTitel,
                Slug = x.Slug,
                keyword =x.keyword
            }).FirstOrDefault(x => x.Id == id);
        }
        public EditTrkCategory? GetDetailes(string slug)
        {
            return _context.TruckCategories.Select(x => new EditTrkCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                ParentId = x.ParentId,
                PictureName = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitel = x.PictureTitel,
                Slug = x.Slug,
                keyword = x.keyword
            }).FirstOrDefault(x => x.Slug == slug);
        }
        public List<TrkCategoryViewModel> GetTrkCategorys()
        {
            return _context.TruckCategories.Select(x => new TrkCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                ParentId = x.ParentId,
                PictureName = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitel = x.PictureTitel,
                Slug = x.Slug,
                keyword = x.keyword
            }).OrderByDescending(x => x.Id).ToList();
        }
        public List<TrkCategoryViewModel>? GetTrkCategorys(long id)
        {
            return _context.TruckCategories.Where(x=>x.Id==id).Select(x => new TrkCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                ParentId = x.ParentId,
                PictureName = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitel = x.PictureTitel,
                Slug = x.Slug,
                keyword = x.keyword
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
