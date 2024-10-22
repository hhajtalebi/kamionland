
using _0_Framework.Infrastructure;
using DiscountManegment.Application.Contract.CustomerDiscountApplication;
using DiscountManegment.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrucksManagement.Application.contracts.TrucksApplication;

namespace ServiceHost.Areas.Admin.Pages.Discounts.CustomerDiscounts
{
    //[Authorize(Roles = Roles.Administator)]
    public class IndexModel : PageModel
    {

        public CoustomerDiscountSearchModel SearchModel;
        public List<CoustomerDiscountViewModel> CustomerDiscounts;
        public SelectList Products;

        private readonly ITrucksApplication _productApplication;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;

        public IndexModel(ITrucksApplication ProductApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = ProductApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }
        [NeedsPermission(DiscountPermissions.ListCustomerDiscount)]
        public void OnGet(CoustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetTrucks(), "Id", "Name");
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount
            {
                Products = _productApplication.GetTrucks()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var customerDiscount = _customerDiscountApplication.GetDetaile(id);
            customerDiscount.Products = _productApplication.GetTrucks();
            
            return Partial("Edit", customerDiscount);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
