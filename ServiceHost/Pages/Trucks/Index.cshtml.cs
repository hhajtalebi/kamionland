using KamionLandQuery.Contracts.TruckCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Trucks
{
    public class IndexModel : PageModel
    {
        private readonly ITrkCategoryQuery _trkCategoryQuery;

        public IndexModel(ITrkCategoryQuery trkCategoryQuery)
        {
            _trkCategoryQuery = trkCategoryQuery;
        }

        public List<TrkCategoryQueryViewModel> GetTrkCategories { get; set; }
        public void OnGet(string slug)
        {
            GetTrkCategories = _trkCategoryQuery.GetTruckCategoryWithCategoryAndTrucks(slug);
        }
    }
}
