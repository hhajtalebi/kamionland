using InventoryManagement.Infrastructure.EFCore;
using KamionLandQuery.Contracts.TruckCategory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Infrastructure.EFCore;
using KamionLandQuery.Contracts.Trucks;
using TrucksManagement.Infrustructuer.EfCore;
using MailChimp.Net.Models;
using TrucksManagement.Domain.TruckAgg;
using _0_Framework.Application;

namespace KamionLandQuery.Querys
{
    public class TrkCategoryQuery : ITrkCategoryQuery
    {
        private readonly TrcksContext _trcksContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public TrkCategoryQuery(TrcksContext trcksContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _trcksContext = trcksContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<TrkCategoryQueryViewModel> GetTruckCategory()
        {
            return _trcksContext.TruckCategories.Select(p => new TrkCategoryQueryViewModel()
            {
                Id = p.Id,
                PictureName = p.Picture,
                PictureTitel = p.PictureTitel,
                PictureAlt = p.PictureAlt,
                Description = p.Description,
                MetaDescription = p.MetaDescription,
                Name = p.Name,
                Slug = p.Slug,
                keyword = p.keyword,
                ParentId = p.ParentId,

            }).ToList();
        }

        public List<TrkCategoryQueryViewModel> GetTruckCategoryWithTrucks()
        {
            var inventory = _inventoryContext.Invevntories.Select(i => new { i.ProductId, i.InitialPrice, i.UnitPrice })
                .ToList();
            var Discount = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.ProductId, x.DiscountRate }).ToList();

            var categoreis = _trcksContext.TruckCategories.Include(x => x.Trucks).Select(x => new TrkCategoryQueryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                PictureName = x.Picture,
                PictureTitel = x.PictureTitel,
                keyword = x.keyword,
                Products = MapProducts(x.Trucks),
                ParentId = x.ParentId,
            }).ToList();

            foreach (var category in categoreis)
            {
                foreach (var truck in category.Products)
                {
                    var inventorysPrice = inventory.FirstOrDefault(x => x.ProductId == truck.Id);

                    if (inventorysPrice != null)
                    {
                        truck.UnitPrice = Convert.ToDouble(inventorysPrice.UnitPrice);

                        var discount = Discount.FirstOrDefault(x => x.ProductId == truck.Id);
                        if (discount != null)
                        {
                            truck.DiscountRate = Discount.FirstOrDefault(x => x.ProductId == truck.Id)!.DiscountRate;

                            var discountAmon = Math.Round(inventorysPrice.UnitPrice * Convert.ToDouble(truck.DiscountRate)) / 100;
                            truck.PriceWithDiscount = (truck.UnitPrice - discountAmon).ToMoney();
                        }
                    }

                }
            }
            return categoreis;

        }
        private static List<TruckQueryViewModel> MapProducts(List<Truck> products)
        {
            return products.Select(product => new TruckQueryViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Picturefull = product.Picture,
                PictureTitel = product.PictureTitel,
                PrictureAlte = product.PrictureAlte,
                ShortDescription = product.ShortDescription,
                MetaDescription = product.MetaDescription,
                Keywords = product.Keywords,
                //CategoryName = product.Category.Name,
                Slug = product.Slug,
                
            }).ToList();

        }
        public List<TrkCategoryQueryViewModel> GetTruckCategoryWithCategoryAndTrucks(string categorySlug)
        {
            var inventory = _inventoryContext.Invevntories.Select(i => new { i.ProductId, i.InitialPrice, i.UnitPrice })
                .ToList();
            var Discount = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.ProductId, x.DiscountRate }).ToList();
            var category = _trcksContext.TruckCategories.FirstOrDefault(x => x.Slug == categorySlug);
            var categoreis = _trcksContext.TruckCategories.Include(x => x.Trucks).Select(x => new TrkCategoryQueryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                PictureName = x.Picture,
                PictureTitel = x.PictureTitel,
                keyword = x.keyword,
                Products = MapProducts(x.Trucks),
                ParentId = x.ParentId,
            }).Where(x => x.ParentId == category.Id).ToList();

            return categoreis;
        }

        public TrkCategoryQueryViewModel GetTruckCategoryWithTrucks(string categorySlug)
        {
            var inventory = _inventoryContext.Invevntories.Select(i => new { i.ProductId, i.InitialPrice, i.UnitPrice })
                .ToList();
            var Discount = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.ProductId, x.DiscountRate }).ToList();

            var category = _trcksContext.TruckCategories.Include(x => x.Trucks).Select(x => new TrkCategoryQueryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                PictureName = x.Picture,
                PictureTitel = x.PictureTitel,
                keyword = x.keyword,
                Products = MapProducts(x.Trucks),
                ParentId = x.ParentId,
            }).FirstOrDefault(x=>x.Slug==categorySlug);

            foreach (var truck in category.Products)
            {
                var inventorysPrice = inventory.FirstOrDefault(x => x.ProductId == truck.Id);

                if (inventorysPrice != null)
                {
                    truck.UnitPrice = Convert.ToDouble(inventorysPrice.UnitPrice);

                    var discount = Discount.FirstOrDefault(x => x.ProductId == truck.Id);
                    if (discount != null)
                    {
                        truck.DiscountRate = Discount.FirstOrDefault(x => x.ProductId == truck.Id)!.DiscountRate;

                        var discountAmon = Math.Round(inventorysPrice.UnitPrice * Convert.ToDouble(truck.DiscountRate)) / 100;
                        truck.PriceWithDiscount = (truck.UnitPrice - discountAmon).ToMoney();
                    }
                }

            }

            return category;
        }
    }
}
