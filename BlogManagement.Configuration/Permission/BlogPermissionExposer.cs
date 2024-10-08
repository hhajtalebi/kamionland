using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;

namespace BlogManagement.Configuration.Permission
{
    public class BlogPermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "مقالات", new List<PermissionDto>
                    {
                        new PermissionDto(BlogPermissions.ListArticel,"لیست مقالات"),
                        new PermissionDto(BlogPermissions.SearchArticel,"جستجو در مقالات"),
                        new PermissionDto(BlogPermissions.CreateArticel,"افزودن مقالات"),
                        new PermissionDto(BlogPermissions.EditArticel,"ویرایش مقالات"),
                    }
                },
                {
                    "دسته بندی مقالات",new List<PermissionDto>
                    {
                        new PermissionDto(BlogPermissions.ListArticelCategory,"لیست  دسته بندی ها"),
                        new PermissionDto(BlogPermissions.SearchArticelCategory,"جستجو در  دسته بندی ها"),
                        new PermissionDto(BlogPermissions.CreateArticelCategory,"افزودن  دسته بندی ها"),
                        new PermissionDto(BlogPermissions.EditArticelCategory,"ویرایش  دسته بندی ها"),

                    }
                }

            };
            }
    }
}
