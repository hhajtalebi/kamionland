using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrucksManagement.Application.contracts.TrkCategoryApplication;
using TrucksManagement.Application.contracts.TrucksApplication;

namespace ServiceHost.Areas.Admin.Pages.Trucks.Trucks
{
    public class CreateModel : PageModel
    {
        private readonly ITrucksApplication _trucksApplication;
        private readonly ITrkCategoryApplication _truckCategoryApplication;

        public CreateModel(ITrucksApplication trucksApplication, ITrkCategoryApplication truckCategoryApplication)
        {
            _trucksApplication = trucksApplication;
            _truckCategoryApplication = truckCategoryApplication;
           
        }


        public CreateTruck Command;
        public List<TrkCategoryViewModel> Liscategory;
        public void OnGet()
        {
            Liscategory = _truckCategoryApplication.GetTrkCategorys();
        }

        public IActionResult OnPost(CreateTruck command)
        {
            _trucksApplication.Create(command);
            return RedirectToPage("./Index");
        }

    }
}
