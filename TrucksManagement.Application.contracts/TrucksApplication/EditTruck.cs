namespace TrucksManagement.Application.contracts.TrucksApplication;

public class EditTruck:CreateTruck
{
    public long Id { get;  set; }
    public string? PictureName { get; set; }
}