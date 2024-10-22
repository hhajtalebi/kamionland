using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contract.InventoryApplication;
using InventoryManegment.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrucksManagement.Application.contracts.TrucksApplication;

namespace ServiceHost.Areas.Admin.Pages.Inventory
{
    //[Authorize(Roles = Roles.Administrator)]
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public InventorySearchModel SearchModel;
        public List<InventoryViewModel> Inventory;
        public SelectList Products;

        private readonly ITrucksApplication _productApplication;
        private readonly IInventoryApplication _inventoryApplication;

        public IndexModel(ITrucksApplication productApplication, IInventoryApplication inventoryApplication)
        {
            _productApplication = productApplication;
            _inventoryApplication = inventoryApplication;
        }

        [NeedsPermission(InventoryPermissions.ListInventory)]
        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetTrucks(), "Id", "Name");
          
            Inventory = _inventoryApplication.search(searchModel);
        }

        [NeedsPermission(InventoryPermissions.CreateInventory)]
        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory
            {
                Products = _productApplication.GetTrucks()
            };
            return Partial("./Create", command);
        }

        [NeedsPermission(InventoryPermissions.CreateInventory)]
        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.Create(command);
            if (result.IsSuccedded!=true)
            {
                return new JsonResult(result.Messege) ;
            }
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var inventory = _inventoryApplication.GetDetalis(id);
            inventory.Products = _productApplication.GetTrucks();
            return Partial("Edit", inventory);
        }

       [NeedsPermission(InventoryPermissions.EditInventory)]
        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InventoryId = id
            };
            return Partial("Increase", command);
        }

       [NeedsPermission(InventoryPermissions.Increase)]
        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetReduce(long id)
        {
            var command = new ReduceInventory()
            {
                InventoryId = id
            };
            return Partial("Reduce", command);
        }

        [NeedsPermission(InventoryPermissions.Reduce)]
        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }

       [NeedsPermission(InventoryPermissions.OperationLog)]
        public IActionResult OnGetLog(long id)
        {
           var log = _inventoryApplication.GetOperationLog(id);
            return Partial("OperationLog",log);
        }
    }
}