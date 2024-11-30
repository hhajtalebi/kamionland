using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.Trucks
{
    public class TruckQueryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public long TruckModel { get; set; }
        public string color { get; set; }
        public bool HasColor { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Picturethum { get; set; }
        public string Picturefull { get; set; }
        public string PrictureAlte { get; set; }
        public string PictureTitel { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public long CategoryId { get; set; }
    }
}
