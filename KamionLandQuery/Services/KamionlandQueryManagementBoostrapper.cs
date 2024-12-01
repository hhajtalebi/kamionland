using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamionLandQuery.Contracts.Blogs;
using KamionLandQuery.Contracts.Blogs.Blog;
using KamionLandQuery.Contracts.Blogs.Blog.ArticelCategory;
using KamionLandQuery.Contracts.comment;
using KamionLandQuery.Contracts.DiscountCoustomer;
using KamionLandQuery.Querys;
using KamionLandQuery.Contracts.Menu;
using KamionLandQuery.Contracts.SlideTrucks;
using KamionLandQuery.Contracts.TruckCategory;

namespace KamionLandQuery.Services
{
    public class KamionlandQueryManagementBoostrapper
    {
        public static void Configur(IServiceCollection services, string contectionString)
        {
            services.AddScoped<IArticelQuery, ArticelQuery>();
            services.AddScoped<IArticelCategory, ArticelCategory>();
            services.AddScoped<IBlogQuery, BlogQuery>();

            services.AddScoped<IMenuQuery, MenuQuery>();
            services.AddScoped<ISlideTrucksQueryModel, SlideTrucksQueryModel>();
            services.AddScoped<ICommentQuery, CommentQuery>();
            services.AddScoped<ICoustomerDiscountQuery, CoustomerDiscountQuery>();


            services.AddScoped<ITrkCategoryQuery, TrkCategoryQuery>();

        }
    }
}
