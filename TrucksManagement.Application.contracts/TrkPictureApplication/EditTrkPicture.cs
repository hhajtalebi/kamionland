namespace TrucksManagement.Application.contracts.TrkPictureApplication;

public class EditTrkPicture : CreateTrkPicture
{
    public long Id { get; set; }
    public string? pictureName { get; set; }
}