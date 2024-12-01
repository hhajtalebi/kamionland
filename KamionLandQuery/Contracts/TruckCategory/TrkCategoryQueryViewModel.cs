using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamionLandQuery.Contracts.Trucks;

namespace KamionLandQuery.Contracts.TruckCategory
{
    public class TrkCategoryQueryViewModel
    {
        public long Id { get; set; }
        public string? PictureName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitel { get; set; }
        public string keyword { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public long? ParentId { get; set; }
        public string? parentName { get; set; }
        public long ProductCount { get; set; }

      
        public List<TruckQueryViewModel> Products { get; set; }
        public List<TruckPicturesQueryViewModel> TruckPictures { get; set; }
    }
}
