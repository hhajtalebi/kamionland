
using KamionLandQuery.Contracts.Menu;

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
    }
}
