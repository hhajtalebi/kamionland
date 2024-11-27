using _0_Framework.Application;

namespace TrucksManagement.Application.contracts.TrucksApplication;

public interface ITrucksApplication
{
    OperationResulte Create(CreateTruck command);
    OperationResulte Edit(EditTruck  command);
    EditTruck GetDetails(long  id);
    public List<TruckViewModel> GetTrucks();
    public List<TruckViewModel>? GetTrucks(long categoryId);


}