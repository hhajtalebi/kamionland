using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using BlogManagement.Domain.ArticelCategoryAgg;

namespace BlogManagement.Domain.ArticelAgg
{
    public class Articel:EntityBase
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlte { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string? CanonicalAddress { get; private set; }
        public DateTime PublishDate { get; private set; }
        public long ArticelCategoryId { get; private set; }
        public ArticelCategory ArticelCategory { get; private set; }

        public Articel(string title, string shortDescription, string description, string picture,
            string pictureAlte, string pictureTitle, string slug, string keywords, string metaDescription,
            string? canonicalAddress, DateTime publishDate, long articelCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlte = pictureAlte;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            PublishDate = publishDate;
            ArticelCategoryId = articelCategoryId;
           
        }
        public void Edit(string title, string shortDescription, string description, string picture, string pictureAlte,
            string pictureTitle, string slug, string keywords, string metaDescription, string? canonicalAddress, 
            DateTime publishDate, long articelCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlte = pictureAlte;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            PublishDate = publishDate;
            ArticelCategoryId = articelCategoryId;
        }
    }
}
