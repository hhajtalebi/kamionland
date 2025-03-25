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
                var categories = _trkCategoryApplication.GetTrkCategorys(category.Id).Prepend(category);
                Trucks = categories.SelectMany(c => _trucksApplication.GetTrucks(c.Id)).ToList();
            }

            if (articelCategory != null)
            {
                var articleCategories = _articelCategory.GetArticelCategorys(articelCategory.Id).Prepend(articelCategory);
                articelcats = articleCategories.SelectMany(ac => _articelApplication.GetArticelsByCategoryId(ac.Id)).ToList();
            }
        }
    }
}
