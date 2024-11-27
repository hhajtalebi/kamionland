using KamionLandQuery.Contracts.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class BlogViewComponent:ViewComponent
    {
        private readonly IBlogQuery _blog;

        public BlogViewComponent(IBlogQuery blog)
        {
            _blog = blog;
        }


        public IViewComponentResult Invoke()
        {
            var blog = _blog.Blogs();
            return View(blog);
        }
    }
}
