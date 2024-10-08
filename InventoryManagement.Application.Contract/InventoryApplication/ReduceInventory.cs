namespace InventoryManagement.Application.Contract.InventoryApplication;

public class ReduceInventory
{
    public long ProductId { get; set; }
    public long Count { get; set; }
    public string Descreption { get; set; }
    public long OrederId { get; set; }
    public long InventoryId { get; set; }

    public ReduceInventory()
    {
        
    }

    public ReduceInventory(long productId, long count, string descreption, long orederId)
    {
        ProductId = productId;
        Count = count;
        Descreption = descreption;
        OrederId = orederId;
    }
}