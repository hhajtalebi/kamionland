namespace InventoryManagement.Application.Contract.InventoryApplication;

public class InventoryViewModel
{
    public long Id { get; set; }
    public string product { get; set; }
    public string Slug { get; set; }
    public long productId { get; set; }
    public double InitialPrice { get;  set; }

    public double UnitPrice { get;set; }
    public bool IsStock { get; set; }
    public long CurrentCount { get; set; }
    public string? CreationDate { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Weight { get; set; }
    public double TotalUnitPrice { get; set; }
    public double TotalInitialPrice { get; set; }
}