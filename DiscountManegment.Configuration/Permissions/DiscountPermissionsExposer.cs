using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;

namespace DiscountManegment.Configuration.Permissions
{
    public class DiscountPermissionsExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                        "CustomerDiscount",new List<PermissionDto>
                            {
                            new PermissionDto(DiscountPermissions.ListCustomerDiscount,"نمایش لیست تخفیف مشتریان"),
                            new PermissionDto(DiscountPermissions.CreateCustomerDiscount,"افزودن تخفیف برای مشتریان"),
                            new PermissionDto(DiscountPermissions.EditCustomerDiscount,"ویرایش تخفیف برای مشتریان"),
                            new PermissionDto(DiscountPermissions.SearchCustomerDiscount,"جستجو در تخفیف مشتریان")
                            }

                },
                {
                    "ColleagueDiscount",new List<PermissionDto>
                    {
                        new PermissionDto(DiscountPermissions.ListColleagueDiscount,"نمایش لیست تخفیف مشتریان"),
                        new PermissionDto(DiscountPermissions.SearchColleagueDiscount,"جستجو در لیست تخفیف برای مشتریان"),
                        new PermissionDto(DiscountPermissions.EditColleagueDiscount,"ویرایش تخفیف برای مشتریان"),
                        new PermissionDto(DiscountPermissions.CreateColleagueDiscount,"افزودن تخفیف برای مشتریان"),
                    }
                }
            };
        }
    }
}
