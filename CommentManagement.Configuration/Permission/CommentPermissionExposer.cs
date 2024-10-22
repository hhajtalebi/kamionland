using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;

namespace CommentManagement.Configuration.Permission
{
    public class CommentPermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "مدیریت کامنت ها",new List<PermissionDto>
                    {
                        new PermissionDto(CommentPermisssions.CommentManagemented,"مدیریت کامنت ها")
                    }
                }
            };
        }
    }
}
