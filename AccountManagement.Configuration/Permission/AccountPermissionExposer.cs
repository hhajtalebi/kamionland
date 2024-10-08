using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;

namespace AccountManagement.Configuration.Permission
{
    public class AccountPermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "حسابهای کاربری",new List<PermissionDto>
                    {
                        new PermissionDto(AccountPermissions.ListAccount,"لیست  حسابهای کاربری"),
                        new PermissionDto(AccountPermissions.CreateAccount,"افزودن  حسابهای کاربری"),
                        new PermissionDto(AccountPermissions.EditAccount,"ویرایش  حسابهای کاربری"),
                        new PermissionDto(AccountPermissions.SearchAccount,"جستجو  حسابهای کاربری"),
                    }

                },
                {
                    "نقش ها",new List<PermissionDto>
                    {
                        new PermissionDto(AccountPermissions.ListRoles,"لیست نقش ها"),
                        new PermissionDto(AccountPermissions.CreateRoles," افزودن نقش ها"),
                        new PermissionDto(AccountPermissions.EditRoles,"ویرایش نقش ها"),
                    }
                }
            };
        }
    }
}
