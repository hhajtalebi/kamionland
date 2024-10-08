using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using blogManagement.Application.Contracts.ArticelCategoryApplication;

namespace BlogManagement.Domain.ArticelCategoryAgg
{
    public interface IArticelCategoryRepository:IRepository<long, ArticelCategory>
    {
        EditArticelCategory? GetDetails(long id);
        List<ArticelCategoryViewModel> Search(ArticelCategorySearchModel searchModel);
        public List<ArticelCategoryViewModel> GetArticleCategories();

    }

}
