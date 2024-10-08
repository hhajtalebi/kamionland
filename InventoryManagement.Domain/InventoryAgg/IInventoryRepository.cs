using _0_Framework.Application;
using _0_Framework.Domain;
using InventoryManagement.Application.Contract.InventoryApplication;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository:IRepository<long,Inventory>
    {

        public Inventory GetBy(long productId);
        EditInventory GetDetalis(long id);
        List<InventoryViewModel> search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);

    }
}
