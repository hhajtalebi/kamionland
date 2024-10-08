namespace InventoryManagement.Domain.InventoryAgg;

public class InventoryOpertion
{
    public long Id { get; private set; }
    public bool Operation { get; set; }
    public long Count { get; private set; }
    public long OperatId { get; private set; }
    public DateTime OperationDate { get; private set; }
    public long CurrentCount { get; private set; }

    public long OrderId { get; private set; }
    public string Description { get; set; }
    public long InventoryId { get; private set; }
    public Inventory Inventory { get; private set; }

    public InventoryOpertion(bool operation, long count, long operatId, long currentCount, string description, long orderId, long inventoryId)
    {

        Operation = operation;
        Count = count;
        OperatId = operatId;
        CurrentCount = currentCount;
        OperationDate = DateTime.Now;
        OrderId = orderId;
        InventoryId = inventoryId;
        Description = description;

    }
}