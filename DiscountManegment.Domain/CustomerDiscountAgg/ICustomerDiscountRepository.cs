using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using DiscountManegment.Application.Contract.CustomerDiscountApplication;

namespace DiscountManegment.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository:IRepository<long,CustomerDiscount >
    {
        EditCustomerDiscount GetDetaile(long id);
        List<CoustomerDiscountViewModel> Search(CoustomerDiscountSearchModel searchmodel);
    }
}
