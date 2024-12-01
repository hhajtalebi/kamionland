using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.TruckCategory
{
    public interface ITrkCategoryQuery
    {
        public List<TrkCategoryQueryViewModel> GetTruckCategory();
        public List<TrkCategoryQueryViewModel> GetTruckCategoryWithTrucks();
        public List<TrkCategoryQueryViewModel> GetTruckCategoryWithCategoryAndTrucks(string categorySlug);
        TrkCategoryQueryViewModel GetTruckCategoryWithTrucks(string categorySlug);
    }
}
