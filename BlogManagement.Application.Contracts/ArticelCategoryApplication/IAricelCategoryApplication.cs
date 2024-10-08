using _0_Framework.Application;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogManagement.Application.Contracts.ArticelCategoryApplication
{
    public interface IAricelCategoryApplication
    {
        OperationResulte Create(CreateArticelCategory command);
        OperationResulte Edit(EditArticelCategory command);
        EditArticelCategory? GetDetails(long  id);
        List<ArticelCategoryViewModel> Search(ArticelCategorySearchModel searchModel);

        public List<ArticelCategoryViewModel> GetArticleCategories();
    }
}
