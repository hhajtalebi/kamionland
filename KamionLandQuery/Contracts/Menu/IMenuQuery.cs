using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.Menu
{
    public interface IMenuQuery
    {
        public List<MenuQueryViewModel> menuList();
    }
}
