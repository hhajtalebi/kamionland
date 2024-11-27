using blogManagement.Application.Contracts.ArticelApplication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrucksManagement.Application.contracts.TrkCategoryApplication;
using TrucksManagement.Application.contracts.TrucksApplication;

namespace ServiceHost.Pages.superpage
{
    public class IndexModel : PageModel
    {

        private readonly IArticelApplication _articelApplication;
        private readonly ITrucksApplication _trucksApplication;
        private readonly ITrkCategoryApplication _trkCategoryApplication;

        public IndexModel(IArticelApplication articelApplication,
            ITrucksApplication trucksApplication,
            ITrkCategoryApplication trkCategoryApplication)
        {
            _articelApplication = articelApplication;
            _trucksApplication = trucksApplication;
            _trkCategoryApplication = trkCategoryApplication;
        }


        public List<TruckViewModel>? Trucks { get; set; }
        public List<ArticelViewModel>? articelcats { get; set; }
        public void OnGet(string Slug)
        {
            var category = _trkCategoryApplication.GetDetailes(Slug);
            if (category != null)
            {
                
                var trkcategory = _trkCategoryApplication.GetTrkCategorys();

                foreach (var cta in trkcategory)
                {
                    Trucks=_trucksApplication.GetTrucks(cta.Id);


                  
                    articelcats = _articelApplication.GetArticels();

                    var ListCategoryparent = _trkCategoryApplication.GetTrkCategorys(cta.Id);
                    foreach (var lcp in ListCategoryparent)
                    {
                        Trucks.AddRange(_trucksApplication.GetTrucks(lcp.Id));



                    }

                }







            }


        }
    }
}
