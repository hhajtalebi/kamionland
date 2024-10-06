using _0_Framework.Application;

namespace TrucksManagement.Application.contracts.TrkPictureApplication;

public interface ITrkPictureApplication
{
    OperationResulte Create(CreateTrkPicture command);
    OperationResulte Edit(EditTrkPicture  command);
    EditTrkPicture GetDetails(long id);
    public List<TrkPictureViewModel> GetTrkPicture();
    OperationResulte Delete(long id);
    OperationResulte Restore(long id);

}