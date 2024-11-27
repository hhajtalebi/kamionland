using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamionLandQuery.Contracts.Blogs.Blog;

namespace KamionLandQuery.Contracts.Blogs.Blog
{
    public interface IArticelQuery
    {
        public List<ArticelQueryModel> GetArticel();
        public ArticelQueryModel? GetDetaile(string slug);
    }
}
