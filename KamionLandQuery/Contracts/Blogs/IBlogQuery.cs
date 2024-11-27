using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamionLandQuery.Contracts.Blogs
{
    public interface IBlogQuery
    {
        public List<BlogQueryViewModel> Blogs();
    }
}
