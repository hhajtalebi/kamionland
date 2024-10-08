using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using blogManagement.Application.Contracts.ArticelCategoryApplication;

namespace blogManagement.Application.Contracts.ArticelApplication
{
    public interface IArticelApplication
    {
        OperationResulte Create(CreateArticel comman);
        OperationResulte Edit(EditArticel comman);
        EditArticel? GetDetails(long  id);
        List<ArticelViewModel> Search(ArticelSearchModel searches);
      

    }
}
