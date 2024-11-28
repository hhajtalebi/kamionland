
using KamionLandQuery.Contracts.Menu;
using TrucksManagement.Application.contracts.TrkCategoryApplication;
using TrucksManagement.Infrustructuer.EfCore;

namespace KamionLandQuery.Querys
{
    public class MenuQuery : IMenuQuery
    {
        private readonly TrcksContext _Context;

        public MenuQuery(TrcksContext Context)
        {
            _Context = Context;
        }
        public List<MenuQueryViewModel> menuList()
        {

            var category = _Context.TruckCategories.Select(x => new MenuQueryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureAlt = x.PictureAlt,
                PictureTitel = x.PictureTitel,
                Slug = x.Slug,
              
                MetaDescription = x.MetaDescription,
                ParentId = x.ParentId,
               
              
            });
            var categorys = category.ToList();
            
            return categorys.ToList();
        }

        public List<TrkCategoryViewModel>? CategoryBase()
        {
            var categoreis = _Context.TruckCategories.Where(x => x.ParentId == 0).Select(x => new TrkCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureAlt = x.PictureAlt,
                PictureTitel = x.PictureTitel,
                Slug = x.Slug,
                PictureName = x.Picture,
                MetaDescription = x.MetaDescription,
                ParentId = x.ParentId,

            }).ToList();

            return categoreis;
        }
        public List<TrkCategoryViewModel>? CategoryBaseParent()
        {
            List<TrkCategoryViewModel>? Listcategory =new List<TrkCategoryViewModel>();
            
            var categoreis = CategoryBase();
            if (categoreis != null)
            {
                foreach (var cta in categoreis)
                {
                    var category = _Context.TruckCategories.Where(x => x.ParentId == cta.Id).Select(x =>
                        new TrkCategoryViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            PictureAlt = x.PictureAlt,
                            PictureTitel = x.PictureTitel,
                            Slug = x.Slug,
                            PictureName = x.Picture,
                            MetaDescription = x.MetaDescription,
                            ParentId = x.ParentId,
                        });
                    Listcategory.AddRange(category);
                }

            }

            return Listcategory;
        }
    }
}
