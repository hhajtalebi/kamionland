using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrucksManagement.Application.contracts.TrkCategoryApplication;
using TrucksManagement.Application.contracts.TrucksApplication;

namespace ServiceHost.Areas.Admin.Pages.Trucks.Trucks
{
    public class EditModel : PageModel
    {
        private readonly ITrucksApplication _truckapplication;
        private readonly ITrkCategoryApplication _truckcategoryapplication;

        public EditModel(ITrucksApplication truckapplication, ITrkCategoryApplication truckcategoryapplication)
        {
            _truckapplication = truckapplication;
            _truckcategoryapplication = truckcategoryapplication;
           
        }
        public EditTruck Command;
        public List<TrkCategoryViewModel> ListCategory;
        public void OnGet(long id)
        {
            Command = _truckapplication.GetDetails(id);
            ListCategory = _truckcategoryapplication.GetTrkCategorys();
        }

        public IActionResult OnPost(EditTruck command , string body)
        {
            command.Description=body;
            _truckapplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
      
}
