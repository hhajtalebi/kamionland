using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace TrucksManagement.Application.contracts.TrkCategoryApplication
{
    public class CreateTrkCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        public string Description { get;  set; }
        public IFormFile? Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitel { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string keyword { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        public long? ParentId { get; set; }
    }
}
