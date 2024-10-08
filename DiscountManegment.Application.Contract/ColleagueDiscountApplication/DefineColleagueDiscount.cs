

using TrucksManagement.Application.contracts.TrucksApplication;

namespace DiscountManegment.Application.Contract.ColleagueDiscountApplication
{

    public class DefineColleagueDiscount
    {
        public long PoroductId { get; set; }
        public int DiscountRate { get; set; }
        public List<TruckViewModel>  Products { get; set; }
    }
}
