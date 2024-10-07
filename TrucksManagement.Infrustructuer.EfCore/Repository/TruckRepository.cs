using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TrucksManagement.Application.contracts.TrucksApplication;
using TrucksManagement.Domain.TruckAgg;

namespace TrucksManagement.Infrustructuer.EfCore.Repository
{
    public class TruckRepository : RepositoryBase<long, Truck>, ITruckRepository
    {
        private readonly TrcksContext _context;
        public TruckRepository(TrcksContext context) : base(context)
        {
            _context = context;
        }

        public Truck? GetProductWithCategory(long Id)
        {
            return _context.Trucks.Include(x => x.Category).FirstOrDefault(x => x.Id == Id);

        }

        public List<TruckViewModel> GetTrucks()
        {
            return _context.Trucks.Select(x => new TruckViewModel()
            {
                Id = x.Id,
                PictureName = x.Picture,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                HasColor = x.HasColor,
                Keywords = x.Keywords,
                Manufacturer = x.Manufacturer,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                PictureTitel = x.PictureTitel,
                PrictureAlte = x.PrictureAlte,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                TruckModel = x.TruckModel,
                Year = x.Year,
                color = x.color
            }).ToList();
        }

        public EditTruck GetDetails(long id)
        {
            return _context.Trucks.Select(x => new EditTruck()
            {
                Id = x.Id,
                PictureName = x.Picture,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                HasColor = x.HasColor,
                Keywords = x.Keywords,
                Manufacturer = x.Manufacturer,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                PictureTitel = x.PictureTitel,
                PrictureAlte = x.PrictureAlte,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                TruckModel = x.TruckModel,
                Year = x.Year,
                color = x.color

            }).FirstOrDefault(x => x.Id == id);


        }
    }
}
