namespace SlideManagement.Applicaion.Contracts.SlideApplication;

public class SlideViewModel
{
    public long Id { get; set; }
    public string Picture { get; set; }
    public string Picturefull { get; set; }
    public string Picturethum { get; set; }
    public string PictureAlte { get; set; }
    public string PictureTitel { get; set; }
    public string Titel { get; set; }
    public string BtnText { get; set; }
    public string Heading { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
    public string Link { get; set; }
    public long? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public long? canonicalId { get; set; }
   
}