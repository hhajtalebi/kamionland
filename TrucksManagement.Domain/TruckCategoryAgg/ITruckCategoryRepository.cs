using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrucksManagement.Application.contracts.TrkCategoryApplication;

namespace TrucksManagement.Domain.TruckCategoryAgg
{
    public interface ITruckCategoryRepository:IRepository<long,TruckCategory>
    {
        EditTrkCategory? GetDetailes(long id);
        EditTrkCategory? GetDetailes(string slug);
        public List<TrkCategoryViewModel> GetTrkCategorys();
        public List<TrkCategoryViewModel>? GetTrkCategorys(long id);
    }
}
