using TrucksManagement.Application.contracts.TrucksApplication;

namespace DiscountManegment.Application.Contract.CustomerDiscountApplication
{
    public class DefineCustomerDiscount
    {
        public long ProductId { get;  set; }
        public int DiscountRate { get;  set; }
        public string StartDate { get;  set; }
        public string EndDate { get;  set; }
        public string Reason { get;  set; }
        public List<TruckViewModel> Products { get; set; }
    }
}
