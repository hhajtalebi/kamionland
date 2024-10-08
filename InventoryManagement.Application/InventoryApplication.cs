using _0_Framework.Application;
using _0_Framework.Application.AuthHelper;
using InventoryManagement.Application.Contract.InventoryApplication;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IAuthHelper _authHelper;

        public InventoryApplication(IInventoryRepository inventoryRepository, IAuthHelper authHelper)
        {
            _inventoryRepository = inventoryRepository;
            _authHelper = authHelper;
        }
        public OperationResulte Create(CreateInventory command)
        {
            var operation = new OperationResulte();
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId && x.Color == command.Color))
                return operation.Failed(ApplicationMeasages.DuplicatedRecord);
            var inventory = new Inventory(command.ProductId, command.UnitPrice, command.Color, command.Size, command.Weight,command.InitialPrice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Edit(EditInventory command)
        {
            var Inventory = _inventoryRepository.GetById(command.Id);
            var operation = new OperationResulte();
            if (Inventory == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId && x.Color == command.Color && x.Id != command.Id))
                return operation.Failed(ApplicationMeasages.DuplicatedRecord);
            Inventory.Edit(command.ProductId, command.UnitPrice, command.Color, command.Size, command.Weight, command.InitialPrice);

            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Increase(IncreaseInventory command)
        {
            var operation = new OperationResulte();
            var inventory = _inventoryRepository.GetById(command.InventoryId);
            if (inventory == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            long operatId = _authHelper.CurrentAccountId();
            inventory.Increase(command.Count, operatId, command.Descreption);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();


        }

        public OperationResulte Reduce(List<ReduceInventory> command)
        {
             long operatId = _authHelper.CurrentAccountId();
            var operation = new OperationResulte();


            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.ProductId);
                inventory.Reduce(item.Count, operatId, item.Descreption, item.OrederId);
               
            }
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResulte Reduce(ReduceInventory command)
        {
            var operation = new OperationResulte();
            var inventory = _inventoryRepository.GetById(command.InventoryId);
            if (inventory == null)
                return operation.Failed(ApplicationMeasages.RecordNotFound);

            long operatId = _authHelper.CurrentAccountId();
            inventory.Reduce(command.Count, operatId, command.Descreption, 0);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditInventory GetDetalis(long Id)
        {
            return _inventoryRepository.GetDetalis(Id);
        }

        public List<InventoryViewModel> search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.search(searchModel);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            return _inventoryRepository.GetOperationLog(inventoryId);
        }
    }
}
