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

       
       

    }
}
