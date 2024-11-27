using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamionLandQuery.Contracts.Blogs.Blog.ArticelCategory;

namespace KamionLandQuery.Contracts.Blogs.Blog.ArticelCategory
{
    public interface IArticelCategory
    {
        public List<ArticelCategoryQueryModel> GetArticelCategorys();
        public List<ArticelCategoryQueryModel> GetArticelCategorysWithArticel();
        public ArticelCategoryQueryModel? GetArticelCategoryBySlug(string slug);
    }
}
