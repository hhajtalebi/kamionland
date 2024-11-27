using _0_Framework.Application.Categoreis;

using CommentManagement.Application.Contracts.CommentApplication;
using KamionLandQuery.Contracts.Blogs.Blog;
using KamionLandQuery.Contracts.Blogs.Blog.ArticelCategory;
using KamionLandQuery.Contracts.comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Blog
{
    public class DetaileArticelModel : PageModel
    {
        public ArticelQueryModel? articel;
        public List<ArticelQueryModel> ListArticel;
        public List<CommentQueryModel> Comment;
        public List<ArticelCategoryQueryModel> ArticelCategorys;


        private readonly IArticelQuery _articelQuery;
        private readonly ICommentQuery _commentQuery;
        private readonly ICommentApplication _commentApplicatiopn;
        private readonly IArticelCategory _articelCategory;
        public DetaileArticelModel(IArticelQuery articelQuery, ICommentQuery commentQuery,
            ICommentApplication commentApplication,IArticelCategory articelCategory)
        {
           
            _articelQuery = articelQuery;
            _commentQuery = commentQuery;
            _commentApplicatiopn = commentApplication;
            _articelCategory=articelCategory;
        }
        public void OnGet(string id)
        {
            articel = _articelQuery.GetDetaile(id);
            ListArticel = _articelQuery.GetArticel();
            Comment = _commentQuery.GetDetailes(articel.Id,CommentType.Article);
            ArticelCategorys = _articelCategory.GetArticelCategorys();
        }

        public IActionResult OnPost(AddComment comment, string slug)
        {
            comment.Website = "mobo";
            comment.Type = CommentType.Article;
            var resulte = _commentApplicatiopn.Add(comment);
            return RedirectToPage("/Blog/DetaileArticel");
        }
    }
}
