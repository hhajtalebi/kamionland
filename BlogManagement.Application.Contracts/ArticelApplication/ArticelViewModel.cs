namespace blogManagement.Application.Contracts.ArticelApplication;

public class ArticelViewModel
{
    public long articelCategoryId;

    public long Id { get; set; }

    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string PublishDate { get; set; }
    public string articelCategory { get; set; }
    public string? Picture { get; set; }
    public string Picturethum { get; set; }
    public string slug { get; set; }
}