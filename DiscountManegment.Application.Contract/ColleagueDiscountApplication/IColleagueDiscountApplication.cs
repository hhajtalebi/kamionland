using _0_Framework.Application;

namespace DiscountManegment.Application.Contract.ColleagueDiscountApplication
{
    public interface IColleagueDiscountApplication
    {
        OperationResulte Define(DefineColleagueDiscount command);
        OperationResulte Edit(EditColleagueDiscount command);
        OperationResulte Delete(long  id);
        OperationResulte Restore(long id);
        EditColleagueDiscount GetDetaile(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel);
    }
}
