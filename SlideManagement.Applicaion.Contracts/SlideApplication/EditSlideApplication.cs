using DocumentFormat.OpenXml.Office2013.Word;

namespace SlideManagement.Applicaion.Contracts.SlideApplication;

public class EditSlideApplication : CreateSlideApplication
{
    public long Id { get; set; }
    public string pictureName { get; set; }
    public string pictureNamefull { get; set; }
    public string pictureNamethum { get; set; }
}