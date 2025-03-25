using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using blogManagement.Application.Contracts.ArticelApplication;
using blogManagement.Application.Contracts.ArticelCategoryApplication;

namespace BlogManagement.Domain.ArticelAgg
{
    public interface IArticelRepository:IRepository<long,Articel>
    {
        EditArticel? GetDetails(long id);
        List<ArticelViewModel> Search(ArticelSearchModel searches);
        public List<ArticelViewModel>? GetArticels();
        public List<ArticelViewModel>? GetArticelsByCategoryId(long categoryId);

    }
}
