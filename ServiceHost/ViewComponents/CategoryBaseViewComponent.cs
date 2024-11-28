using KamionLandQuery.Contracts.Menu;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CategoryBaseViewComponent:ViewComponent
    {
        private readonly IMenuQuery _menuQuery;

        public CategoryBaseViewComponent(IMenuQuery menuQuery)
        {
            _menuQuery = menuQuery;
        }

        public IViewComponentResult Invoke()
        {
            var category= _menuQuery.CategoryBaseParent();
            return View(category);
        }
    }
}
