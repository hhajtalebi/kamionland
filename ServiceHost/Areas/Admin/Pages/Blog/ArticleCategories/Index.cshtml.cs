using blogManagement.Application.Contracts.ArticelCategoryApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Blog.ArticleCategories
{
    public class IndexModel : PageModel
    {
        public ArticelCategorySearchModel SearchModel;
        public List<ArticelCategoryViewModel> ArticleCategories;

        private readonly IAricelCategoryApplication _articleCategoryApplication;

        public IndexModel(IAricelCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticelCategorySearchModel searchModel)
        {
            ArticleCategories = _articleCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateArticelCategory());
        }

        public JsonResult OnPostCreate(CreateArticelCategory command)
        {
            var result = _articleCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _articleCategoryApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditArticelCategory command)
        {
            var result = _articleCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
