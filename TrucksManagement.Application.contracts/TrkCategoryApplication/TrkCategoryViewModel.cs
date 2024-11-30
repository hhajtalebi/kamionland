namespace TrucksManagement.Application.contracts.TrkCategoryApplication;

public class TrkCategoryViewModel : EditTrkCategory
{
    public string? parentName { get; set; }
    public long ProductCount { get; set; }
}