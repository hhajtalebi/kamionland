using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.InventoryApplication
{
    public interface IInventoryApplication
    {
        OperationResulte Create(CreateInventory command);
        OperationResulte Edit(EditInventory command);
        OperationResulte Increase(IncreaseInventory command);
        OperationResulte Reduce(List<ReduceInventory> command);
        OperationResulte Reduce(ReduceInventory command);
        EditInventory GetDetalis(long Id);
        List<InventoryViewModel> search (InventorySearchModel  searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);


    }
}
