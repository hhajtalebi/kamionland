using KamionLandQuery.Contracts.Blogs;
using KamionLandQuery.Contracts.DiscountCoustomer;
using KamionLandQuery.Contracts.TruckCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class DiscountCoustomerViewComponent : ViewComponent
    {
        private readonly ITrkCategoryQuery _trkCategoryQuery;

        public DiscountCoustomerViewComponent(ITrkCategoryQuery trkCategoryQuery)
        {
            _trkCategoryQuery = trkCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var categoryWithTrucks = _trkCategoryQuery.GetTruckCategoryWithTrucks();
            return View(categoryWithTrucks);
        }
    }
}
