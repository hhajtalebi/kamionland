using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.Blogs
{
    public class BlogQueryViewModel
    {
        public long articelCategoryId { get; set; }
        public string slug { get; set; }

        public long Id { get; set; }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PublishDate { get; set; }
        public string articelCategory { get; set; }
        public string? Picture { get; set; }
        public string Picturethum { get; set; }
    }
}
