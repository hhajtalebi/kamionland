using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrucksManagement.Application.contracts.TrkCategoryApplication;

namespace KamionLandQuery.Contracts.Menu
{
    public interface IMenuQuery
    {
        public List<MenuQueryViewModel> menuList();
        public List<TrkCategoryViewModel>? CategoryBase();
        public List<TrkCategoryViewModel>? CategoryBaseParent();
        public List<TrkCategoryViewModel>? CategoryBaseParentNextOne();
    }
}
