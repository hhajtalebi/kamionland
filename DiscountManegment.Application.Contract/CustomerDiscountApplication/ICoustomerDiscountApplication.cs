using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManegment.Application.Contract.CustomerDiscountApplication
{
    public interface ICustomerDiscountApplication
    {
        OperationResulte Define(DefineCustomerDiscount command);
        OperationResulte Edit(EditCustomerDiscount command);

        EditCustomerDiscount GetDetaile(long id);
        List<CoustomerDiscountViewModel> Search(CoustomerDiscountSearchModel searchmodel);
    }
}
