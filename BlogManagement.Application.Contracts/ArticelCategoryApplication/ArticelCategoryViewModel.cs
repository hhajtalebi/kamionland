namespace blogManagement.Application.Contracts.ArticelCategoryApplication;

public class ArticelCategoryViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public int ShowOrder { get; set; }
    public string creationDate { get; set; }
    public long Id { get; set; }
    public int ArticlesCount { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
}