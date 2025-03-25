using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using TrucksManagement.Application.contracts.TrucksApplication;

namespace TrucksManagement.Domain.TruckAgg
{
    public interface ITruckRepository:IRepository<long,Truck>
    {
        public Truck? GetProductWithCategory(long Id);
        public List<TruckViewModel> GetTrucks();
        EditTruck GetDetails(long id);
        public List<TruckViewModel>? GetTrucks(long categoryId);
        public TruckViewModel? GetTruckBySlug(string slug);

    }
}
