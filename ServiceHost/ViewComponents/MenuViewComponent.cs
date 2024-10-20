
using KamionLandQuery.Contracts.Menu;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IMenuQuery _menuQuery;

        public MenuViewComponent(IMenuQuery menuQuery)
        {
            _menuQuery = menuQuery;
        }
        public IViewComponentResult Invoke()
        {
            var category = _menuQuery.menuList();
            var result = new MenuViewMOdel()
            {
                siteCategorys = _menuQuery.menuList(),
               
            };
            return View(result);
        }
    }
}
