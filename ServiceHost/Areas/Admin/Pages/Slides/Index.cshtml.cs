using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SlideManagement.Applicaion.Contracts.SlideApplication;
using TrucksManagement.Application.contracts.TrkCategoryApplication;

namespace ServiceHost.Areas.Admin.Pages.Slides
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<SlideViewModel> Slides;

        private readonly ISlideApplication _slideApplication;
        private readonly ITrkCategoryApplication _trkCategoryApplication;
        public IndexModel(ISlideApplication slideApplication, ITrkCategoryApplication trkCategoryApplication)
        {
            _slideApplication = slideApplication;
            _trkCategoryApplication = trkCategoryApplication;
        }

        public void OnGet()
        {
            var category = _trkCategoryApplication.GetTrkCategorys();
            Slides = _slideApplication.GetList();
           
            Slides.ForEach(slide => slide.CategoryName = category.FirstOrDefault(x => x.Id == slide.CategoryId).Name);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateSlideApplication();
            command.ListCategoresp = _trkCategoryApplication.GetTrkCategorys();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateSlideApplication command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetDetailes(id);
            slide.ListCategoresp = _trkCategoryApplication.GetTrkCategorys();
            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditSlideApplication command)
        {
            var result = _slideApplication.Update(command);
            if (result.IsSuccedded == false)
            {
                return new JsonResult(result.Messege, Message = result.Messege);
            }

            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _slideApplication.Delete(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Messege;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _slideApplication.Restore(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Messege;
            return RedirectToPage("./Index");
        }
    }
}
