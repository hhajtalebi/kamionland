using DiscountManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using KamionLandQuery.Contracts.DiscountCoustomer;
using TrucksManagement.Infrustructuer.EfCore;
using DiscountManegment.Application.Contract.CustomerDiscountApplication;

namespace KamionLandQuery.Querys
{
    public class CoustomerDiscountQuery:ICoustomerDiscountQuery
    {
        private readonly DiscountContext _context;
        private readonly TrcksContext _shopContext;

        public CoustomerDiscountQuery(DiscountContext context, TrcksContext shopContext)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public List<CoustomerDiscountQueryViewModel>? GetDiscountCoustomers()
        {
            var products = _shopContext.Trucks.Select(p => new { p.Id, p.Name,p.Picture }).ToList();

            var query = _context.CustomerDiscounts.Select(d => new CoustomerDiscountQueryViewModel()
            {
                Id = d.Id,
                ProductId = d.ProductId,
                DiscountRate = d.DiscountRate,
                EndDate = d.EndDate.ToFarsi(),
                StartDate = d.StartDate.ToFarsi(),
                StartDateGr = d.StartDate,
                EndDateGr = d.EndDate,
                Reason = d.Reason,
                CreationDate = d.CreationDateTime.ToFarsi()
            });

            var discount = query.OrderByDescending(d => d.Id).ToList();
            foreach (var item in discount)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)!.Name;
                item.PictureName = products.FirstOrDefault(x => x.Id == item.ProductId)!.Picture;
                
            }
            return discount;

        }
    }
}
