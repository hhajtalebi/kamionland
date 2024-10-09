using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;

namespace SlideManagement.Applicaion.Contracts.SlideApplication
{
    public interface ISlideApplication
    {
        OperationResulte Create(CreateSlideApplication command);
        OperationResulte Update(EditSlideApplication  command);
        OperationResulte Delete(long id);
        OperationResulte Restore(long id);

        EditSlideApplication GetDetailes(long id);

        List<SlideViewModel> GetList();


    }
}
