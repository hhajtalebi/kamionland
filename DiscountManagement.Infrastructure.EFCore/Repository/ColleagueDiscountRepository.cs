using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManegment.Application.Contract.ColleagueDiscountApplication;
using DiscountManegment.Domain.ColleagueDiscountbtAgg;
using TrucksManagement.Infrustructuer.EfCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository:RepositoryBase<long,Colleague>,IColleagueDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly TrcksContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext discountcontext,TrcksContext shopContext) : base(discountcontext)
        {
            _discountContext = discountcontext;
            _shopContext = shopContext;
        }

     

        public EditColleagueDiscount? GetDetaile(long id)
        {
            return _discountContext.Colleagues.Select(c => new EditColleagueDiscount()
            {
                Id = c.Id,
              DiscountRate = c.DiscountRate,
              PoroductId = c.PoroductId,
              
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel)
        {
            var products = _shopContext.Trucks.Select(p => new { p.Id, p.Name }).ToList();
            var query = _discountContext.Colleagues.Select(x => new ColleagueDiscountViewModel()
            {
                Id=x.Id,
                DiscountRate = x.DiscountRate,
                PoroductId = x.PoroductId,
                CreateDateTime = x.CreationDateTime.ToFarsi(),
                Isdeleted = x.IsDeleted
                 
            });
            if (searchmodel.PoroductId > 0)
                query = query.Where(x => x.PoroductId == searchmodel.PoroductId);
            var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(discount =>
                discount.product = products.FirstOrDefault(p => p.Id == discount.PoroductId)?.Name);
            return discount;

        }
    }
}
