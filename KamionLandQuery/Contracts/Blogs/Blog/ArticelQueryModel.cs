﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.Blogs.Blog
{
    public class ArticelQueryModel
    {
        public long Id { get; set; }
        public string Title { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlte { get;  set; }
        public string PictureTitle { get;  set; }
        public string Slug { get;  set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        public string? CanonicalAddress { get;  set; }
        public DateTime PublishDate { get;  set; }
        public long ArticelCategoryId { get;  set; }
        public string ArticelCategoryName { get; set; }
    }
}
