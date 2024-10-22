using _0_Framework.Infrastructure;
using blogManagement.Application.Contracts.ArticelApplication;
using blogManagement.Application.Contracts.ArticelCategoryApplication;
using BlogManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Blog.Articles
{
    public class IndexModel : PageModel
    {
        public ArticelSearchModel SearchModel;
        public List<ArticelViewModel> Articles;
        public SelectList ArticleCategories;

        private readonly IArticelApplication _articleApplication;
        private readonly IAricelCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticelApplication articleApplication, IAricelCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        [NeedsPermission(BlogPermissions.ListArticel)]

        public void OnGet(ArticelSearchModel searchModel)
        {
            if (searchModel==null)
            {
                searchModel = new ArticelSearchModel();
            }
          //  ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");

            Articles = _articleApplication.Search(searchModel);
        }
    }
}
