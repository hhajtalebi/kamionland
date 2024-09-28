using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;

namespace TrucksManagement.Domain.TruckAgg
{
    public interface ITruckRepository:IRepository<long,Truck>
    {
        public Truck? GetProductWithCategory(long Id);

    }
}
