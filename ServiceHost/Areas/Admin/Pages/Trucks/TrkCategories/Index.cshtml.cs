using _0_Framework.Infrastructure;
using AccountManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrucksManagement.Application.contracts.TrkCategoryApplication;

namespace ServiceHost.Areas.Admin.Pages.Trucks.TrkCategories
{
    public class IndexModel : PageModel
    {
        private readonly ITrkCategoryApplication _trkCategoryApplication;

        public IndexModel(ITrkCategoryApplication trkCategoryApplication)
        {
            _trkCategoryApplication = trkCategoryApplication;
        }

        public List<TrkCategoryViewModel>? ListCategory;
        //[NeedsPermission(SitePermissions.ListSiteCategory)]

        public void OnGet()
        {
            ListCategory = _trkCategoryApplication.GetTrkCategorys();
        }

        public IActionResult OnGetCreate()
        {
            var model=new CreateTrkCategory();
            model.ChildCategories= _trkCategoryApplication.GetTrkCategorys();
            return Partial("./Create",model);

        }

        public JsonResult OnPostCreate(CreateTrkCategory command)
        {
            command.Slug = command.Name;
        
            var result = _trkCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var category = _trkCategoryApplication.GetDetailes(id);
            category.ChildCategories = _trkCategoryApplication.GetTrkCategorys();
            return Partial("./Edit",category);

        }

        public JsonResult OnPostEdit(EditTrkCategory command)
        {
            command.Slug=command.Name;
            var result = _trkCategoryApplication.Edit(command);
            return new JsonResult(result);
        }

    }
}
