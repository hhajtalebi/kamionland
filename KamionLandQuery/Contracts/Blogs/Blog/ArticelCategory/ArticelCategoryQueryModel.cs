﻿namespace KamionLandQuery.Contracts.Blogs.Blog.ArticelCategory
{
    public class ArticelCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public int ShowOrder { get;  set; }
        public string Slug { get;  set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        public string CanonicalAddress { get;  set; }
        public int  ArticelCategoryCount { get; set; }
        public List<ArticelQueryModel> Articels { get; set; }

    }
}
