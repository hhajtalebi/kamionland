using blogManagement.Application.Contracts.ArticelApplication;
using KamionLandQuery.Contracts.Blogs.Blog.ArticelCategory;
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
        private readonly IArticelCategory _articelCategory;

        public IndexModel(IArticelApplication articelApplication,
            ITrucksApplication trucksApplication,
            ITrkCategoryApplication trkCategoryApplication, IArticelCategory articelCategory)
        {
            _articelApplication = articelApplication;
            _trucksApplication = trucksApplication;
            _trkCategoryApplication = trkCategoryApplication;
            _articelCategory = articelCategory;
        }


        public List<TruckViewModel>? Trucks { get; set; }
        public List<ArticelViewModel>? articelcats { get; set; }
        public void OnGet(string Slug)
        {
            var category = _trkCategoryApplication.GetDetailes(Slug);
            var articelCategory = _articelCategory.GetArticelCategoryBySlug(Slug);
            if (category != null)
            {
                Trucks = _trucksApplication.GetTrucks(category.Id);

                var ListCategoryparent = _trkCategoryApplication.GetTrkCategorys(category.Id);
                foreach (var lcp in ListCategoryparent)
                {
                    Trucks.AddRange(_trucksApplication.GetTrucks(lcp.Id));

                }
            }

            if (articelCategory != null)
            {
                articelcats = _articelApplication.GetArticelsByCategoryId(articelCategory.Id);

                var aritcelcategoryparent = _articelCategory.GetArticelCategorys(articelCategory.Id);
                foreach (var parentArticel in aritcelcategoryparent)
                {
                    articelcats.AddRange(_articelApplication.GetArticelsByCategoryId(parentArticel.Id));
                }
            }


        }
    }
}
