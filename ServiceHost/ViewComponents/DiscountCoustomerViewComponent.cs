using KamionLandQuery.Contracts.Blogs;
using KamionLandQuery.Contracts.DiscountCoustomer;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class DiscountCoustomerViewComponent : ViewComponent
    {
        private readonly ICoustomerDiscountQuery _coustomerDiscountQuery;

        public DiscountCoustomerViewComponent(ICoustomerDiscountQuery coustomerDiscountQuery)
        {
            _coustomerDiscountQuery = coustomerDiscountQuery;
        }


        public IViewComponentResult Invoke()
        {
            var discount = _coustomerDiscountQuery.GetDiscountCoustomers();
            return View(discount);
        }
    }
}
