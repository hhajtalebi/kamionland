using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrucksManagement.Application.contracts.TrkCategoryApplication;
using TrucksManagement.Application.contracts.TrucksApplication;

namespace ServiceHost.Areas.Admin.Pages.Trucks.Trucks
{
    public class IndexModel : PageModel
    {
        private readonly ITrucksApplication _trucksApplication;
        private readonly ITrkCategoryApplication _trkCategoryApplication;

        public IndexModel(ITrucksApplication trucksApplication, ITrkCategoryApplication trkCategoryApplication)
        {
            _trucksApplication = trucksApplication;
            _trkCategoryApplication = trkCategoryApplication;
        }

        public List<TruckViewModel> GetTrucks;
      
        public void OnGet()
        {
            GetTrucks=_trucksApplication.GetTrucks();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateTruck();
            command.categoryList = _trkCategoryApplication.GetTrkCategorys();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateTruck command)
        {
            command.color = "fff";
            command.Manufacturer = "ولوو";
            var result = _trucksApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {

            var product = _trucksApplication.GetDetails(id);
            product.categoryList = _trkCategoryApplication.GetTrkCategorys();
            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditTruck command)
        {

            if (ModelState.IsValid)
            {
            }

            var result = _trucksApplication.Edit(command);
            return new JsonResult(result);
        }

    }
}
