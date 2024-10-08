using blogManagement.Application.Contracts.ArticelCategoryApplication;

namespace blogManagement.Application.Contracts.ArticelApplication;

public class ArticelSearchModel
{
    public string Title { get; set; }
    public long CategoryId { get; set; }
    public List<ArticelCategoryViewModel> ArticelCategory { get; set; }
}