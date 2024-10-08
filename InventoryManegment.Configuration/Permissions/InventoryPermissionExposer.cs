using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace InventoryManegment.Configuration.Permissions
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "انبار داری", new List<PermissionDto>
                    {
                        new PermissionDto(InventoryPermissions.ListInventory, "لیست انبار"),
                        new PermissionDto(InventoryPermissions.SearchInventory,"جستجو  در انبار "),
                        new PermissionDto(InventoryPermissions.CreateInventory, "افزودن به انبار"),
                        new PermissionDto(InventoryPermissions.EditInventory, "ویرایش انبار"),
                        new PermissionDto(InventoryPermissions.Increase, "افزایش موجودی"),
                        new PermissionDto(InventoryPermissions.Reduce, "کاهش موجودی"),
                        new PermissionDto(InventoryPermissions.OperationLog, "گزارش تراکنش ها"),
                    }
                }
            };
        }
    }
}