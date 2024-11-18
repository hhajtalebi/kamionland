using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Microsoft.AspNetCore.Http;
using TrucksManagement.Application.contracts.TrkCategoryApplication;

namespace TrucksManagement.Application.contracts.TrucksApplication
{
    public class CreateTruck:EntityBase
    {
        public string Name { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Code { get; set; }
        public long TruckModel { get; set; }
        public string color { get; set; }
        public bool HasColor { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public IFormFile Picture { get; set; }
        public string PrictureAlte { get; set; }
        public string PictureTitel { get; set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        public string Slug { get;  set; }
        public long CategoryId { get;  set; }
        public List<TrkCategoryViewModel>? categoryList { get; set; }
    }
}
