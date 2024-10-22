using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "محصولات", new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListProducts, "لیست محصولات"),
                        new PermissionDto(ShopPermissions.SearchProducts, "جستجو در محصولات"),
                        new PermissionDto(ShopPermissions.CreateProduct, "افزودن کالا"),
                        new PermissionDto(ShopPermissions.EditProduct, "ویرایش کالا"),
                    }
                },
                {
                    "دسته بندی محصولات", new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.SearchProductCategories, "جستجو در گروه محصولات"),
                        new PermissionDto(ShopPermissions.ListProductCategories, "لیست گروه محصولات"),
                        new PermissionDto(ShopPermissions.CreateProductCategory, "افزودن به لیست گروه محصولات"),
                        new PermissionDto(ShopPermissions.EditProductCategory, "ویرایش گروه محصولات"),
                    }
                },
                {
                    "اسلایدر",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListSlide, "لیست اسلایدر ها"),
                        new PermissionDto(ShopPermissions.CreateSlide, "افزودن اسلایدر ها"),
                        new PermissionDto(ShopPermissions.Editlide, "ویرایش اسلایدر ها"),

                    }
                }
            };
        }
    }
}