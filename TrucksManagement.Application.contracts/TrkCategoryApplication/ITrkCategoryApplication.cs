using _0_Framework.Application;

namespace TrucksManagement.Application.contracts.TrkCategoryApplication;

public interface ITrkCategoryApplication
{
    OperationResulte Create(CreateTrkCategory command);
    OperationResulte Edit(EditTrkCategory  command);
    EditTrkCategory GetDetailes(long id);
    public EditTrkCategory? GetDetailes(string slug);
    public List<TrkCategoryViewModel> GetTrkCategorys();
    public List<TrkCategoryViewModel>? GetTrkCategorys(long id);
}