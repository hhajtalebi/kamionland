using _0_Framework.Domain;
using DiscountManegment.Application.Contract.ColleagueDiscountApplication;

namespace DiscountManegment.Domain.ColleagueDiscountbtAgg
{
    public interface IColleagueDiscountRepository:IRepository<long,Colleague>
    {
      
        EditColleagueDiscount GetDetaile(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel);
    }
}
