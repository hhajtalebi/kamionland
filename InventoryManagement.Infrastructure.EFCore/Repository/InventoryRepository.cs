using _0_Framework.Application;
using _0_Framework.Application.AuthHelper;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.AccountApplication;
using InventoryManagement.Application.Contract.InventoryApplication;
using InventoryManagement.Domain.InventoryAgg;
using TrucksManagement.Infrustructuer.EfCore;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository:RepositoryBase<long, Inventory>,IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly TrcksContext _shopContext;
        private readonly IAuthHelper _authHelper;
        private readonly IAccountApplication _accountApplication;
        public InventoryRepository(InventoryContext inventoryContext, TrcksContext shopContext, IAuthHelper authHelper) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
            _authHelper = authHelper;
        }

        public Inventory GetBy(long productId)
        {
            return _inventoryContext.Invevntories.FirstOrDefault(x => x.ProductId == productId);
        }
        public EditInventory? GetDetalis(long id)
        {
            return _inventoryContext.Invevntories.Select(x => new EditInventory()
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Color = x.Color,
                Size = x.Size,
                Weight = x.Weight,
                InitialPrice = x.InitialPrice,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryViewModel> search(InventorySearchModel searchModel)
        {
            var product = _shopContext.Trucks.Select(x => new { x.Id, x.Name,x.Slug }).ToList();
            var query = _inventoryContext.Invevntories.Select(x => new InventoryViewModel()
            {
                Id = x.Id,
                productId = x.ProductId,
                
                UnitPrice = x.UnitPrice,
                IsStock = x.InStock,
                CurrentCount = x.CalculateCurrentCount(),
                CreationDate = x.CreationDateTime.ToFarsi(),
                Color = x.Color,
                Size = x.Size,
                Weight = x.Weight,
                InitialPrice = x.InitialPrice,
                TotalUnitPrice=x.UnitPrice*x.CalculateCurrentCount(),
                TotalInitialPrice=x.InitialPrice*x.CalculateCurrentCount(),
            });
            if (searchModel.productId > 0)
                query = query.Where(x => x.productId == searchModel.productId);
            if (searchModel.IsStock)
                query = query.Where(x => !x.IsStock);
            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(item =>
            {
                item.product = product.FirstOrDefault(x => x.Id == item.productId)?.Name;
                item.Slug = product.FirstOrDefault(x => x.Id == item.productId)?.Slug;

            });

            return inventory;
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var account = _authHelper.CurrentAccountInfo();
            var Inventory = _inventoryContext.Invevntories.FirstOrDefault(x => x.Id == inventoryId);
            return Inventory.OpertionList.Select(x => new InventoryOperationViewModel()
            {
                
                Id = x.Id,
                Description = x.Description,
                OperationDate = x.OperationDate.ToFarsi(),
                Count = x.Count,
                Operation = x.Operation,
                OrderId = x.OrderId,
                OperatorId = x.OperatId,
                CurrentCount = x.CurrentCount,
                Operator = account.Role +"-"+ account.Fullname,

            }).ToList();
        }
    }
}
