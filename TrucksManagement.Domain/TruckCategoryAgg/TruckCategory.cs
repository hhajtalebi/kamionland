using _0_Framework.Application;
using _0_Framework.Domain;
using System.ComponentModel.DataAnnotations;
using TrucksManagement.Domain.TruckAgg;

namespace TrucksManagement.Domain.TruckCategoryAgg
{
    public class TruckCategory:EntityBase
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitel { get; private set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string keyword { get; private set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; private set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; private set; }
        public long? ParentId { get; private set; }
        public List<Truck> Trucks { get; private set; }

        public TruckCategory()
        {
            Trucks=new List<Truck>();
        }

        public TruckCategory(string name, string description, string picture, string pictureAlt,
            string pictureTitel, string keyword, string metaDescription, string slug, long? parentId)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitel = pictureTitel;
            this.keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
            ParentId = parentId;
           
        }
        public void Edit(string name, string description, string picture, string pictureAlt,
            string pictureTitel, string keyword, string metaDescription, string slug, long? parentId)
        {
            Name = name;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                 Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitel = pictureTitel;
            this.keyword = keyword;
            MetaDescription = metaDescription;
            Slug = slug;
            ParentId = parentId;

        }
    }
}
