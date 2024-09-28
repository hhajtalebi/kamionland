using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using TrucksManagement.Domain.TruckCategoryAgg;

namespace TrucksManagement.Domain.TruckAgg
{
    public class Truck: EntityBase
    {
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Code { get; private set; }
        public long TruckModel { get; private set; }
        public string color { get; private set; }
        public bool HasColor { get; private set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Picture { get; private set; }
        public string PrictureAlte { get; private set; }
        public string PictureTitel { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public long CategoryId { get; private set; }

        public TruckCategory Category { get; private set; }


        public Truck(string name, string shortDescription, string description, string code, 
            long truckModel, string color, bool hasColor, int year, string manufacturer, string picture,
            string prictureAlte, string pictureTitel, string keywords, string metaDescription,
            string slug, long categoryId)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            Code = code;
            TruckModel = truckModel;
            this.color = color;
            HasColor = hasColor;
            Year = year;
            Manufacturer = manufacturer;
            Picture = picture;
            PrictureAlte = prictureAlte;
            PictureTitel = pictureTitel;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
           
        }

        public void Edit(string name, string shortDescription, string description, string code,
            long truckModel, string color, bool hasColor, int year, string manufacturer, string picture,
            string prictureAlte, string pictureTitel, string keywords, string metaDescription,
            string slug, long categoryId)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            Code = code;
            TruckModel = truckModel;
            this.color = color;
            HasColor = hasColor;
            Year = year;
            Manufacturer = manufacturer;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PrictureAlte = prictureAlte;
            PictureTitel = pictureTitel;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;

        }
    }
    
}
