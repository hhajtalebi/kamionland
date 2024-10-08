using TrucksManagement.Application.contracts.TrucksApplication;

namespace InventoryManagement.Application.Contract.InventoryApplication;

public class CreateInventory
{
    public long ProductId { get; set; }
    public double InitialPrice { get;  set; }

    public double UnitPrice { get; set; }
    public string Color { get;  set; }
    //سایز
    public string Size { get;  set; }
    //وزن
    public string Weight { get;  set; }
    public List<TruckViewModel> Products { get; set; }
}