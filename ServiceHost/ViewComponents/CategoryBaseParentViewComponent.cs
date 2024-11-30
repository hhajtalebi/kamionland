using KamionLandQuery.Contracts.Menu;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CategoryBaseParentViewComponent:ViewComponent
    {
        private readonly IMenuQuery _menuQuery;

        public CategoryBaseParentViewComponent(IMenuQuery menuQuery)
        {
            _menuQuery = menuQuery;
        }

        public IViewComponentResult Invoke()
        {
            var category= _menuQuery.CategoryBaseParentNextOne();
            return View(category);
        }
    }
}
