using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using TrucksManagement.Application.contracts.TrkPictureApplication;

namespace TrucksManagement.Domain.TruckPictureAgg
{
    public interface ITruckPictureRepository:IRepository<long,TruckPicture>
    {
        TruckPicture? GetTructPictureWithTruckAndCategory(long Id);
        EditTrkPicture GetDetails(long id);
        public List<TrkPictureViewModel> TrkPicturesList();

    }
}
