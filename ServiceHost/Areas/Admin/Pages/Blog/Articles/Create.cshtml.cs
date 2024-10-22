using _0_Framework.Infrastructure;
using blogManagement.Application.Contracts.ArticelApplication;
using blogManagement.Application.Contracts.ArticelCategoryApplication;
using BlogManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrucksManagement.Application.contracts.TrkCategoryApplication;

namespace ServiceHost.Areas.Admin.Pages.Blog.Articles
{
    public class CreateModel : PageModel
    {
        public CreateArticel Command;
        public SelectList ArticleCategories;
        public List<TrkCategoryViewModel> SiteCategories { get; set; }


        private readonly IArticelApplication _articleApplication;
        private readonly IAricelCategoryApplication _articleCategoryApplication;
        private readonly ITrkCategoryApplication _siteCategoryApplication;
        public CreateModel(IArticelApplication articleApplication,
            IAricelCategoryApplication articleCategoryApplication, ITrkCategoryApplication siteCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
            _siteCategoryApplication = siteCategoryApplication;
        }
        [NeedsPermission(BlogPermissions.EditArticel)]

        public void OnGet()
        {
            ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
            SiteCategories=_siteCategoryApplication.GetTrkCategorys();
        }

        public IActionResult OnPost(CreateArticel command)
        {
           
            var result = _articleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
